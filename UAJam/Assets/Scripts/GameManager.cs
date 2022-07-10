using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject TextPrompt;
    [SerializeField] private GameObject TextPromptBG;
    
    public string TexttoPrompt;
    private bool isInSpiritWorld = false;

    [SerializeField] private GameObject camera;
    [SerializeField] private float cameraBaseY = 2f;
    [SerializeField] private float cameraGoUpBy = 11.5f;
    [SerializeField] private float camera1stBorder = 6f;
    [SerializeField] private float camera2ndBorder = 12f;
    
    [SerializeField] private Player player;
    [SerializeField] private List<Campfire> campfires;

    [SerializeField] private List<GameObject> evilSpirits;
    [SerializeField] private string spiritText;
    
    [SerializeField] public List<Collectible> collectibles;
    private int collectiblesCollected = 0;
    private int collectiblesCount;

    [SerializeField] public Goal goal;

    [SerializeField] private Tilemap baseTileMap;
    [SerializeField] private Tilemap pathTileMap;
    [SerializeField] private Tilemap hidePathTileMap;

    [FormerlySerializedAs("maxDistanceFromCampfire")] 
    [SerializeField] double maxDistanceToInteract = 1d;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        collectiblesCount = collectibles.Count;
        foreach (GameObject evilSpirit in evilSpirits)
        {
            evilSpirit.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        baseTileMap.gameObject.SetActive(true);
        pathTileMap.gameObject.SetActive(false);
        hidePathTileMap.gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        
        bool playerInRange = false;
        double distanceToPlayer;
        
        //Check if player hit monster
        if (player.hitMonster)
        {

            playerInRange = true;
            player.hasControls = false;
            
            TextPrompt.SetActive(true);
            TextPromptBG.SetActive(true);
                    
            TexttoPrompt = spiritText; 
            TextPrompt.GetComponent<Text>().text = TexttoPrompt;
            //Dialogue

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.hasControls = true;
                player.hitMonster = false;
                isInSpiritWorld = false;
                
                player.transform.position = new Vector3(player.lastCampfireCoordX, player.lastCampfireCoordY, 0f); 
                
                TextPrompt.SetActive((false));
                TextPromptBG.SetActive(false);
            }

        }
        
        //Check if next to the goal ( end is near)
        distanceToPlayer = Vector3.Distance(goal.transform.position, player.transform.position);
        if (distanceToPlayer < maxDistanceToInteract)
        {
            
            //Do canvas stuff here
            //Only freeze if collected everything
            if (collectiblesCollected == collectiblesCount)
            {
                player.speed = 0f;
                player.hasControls = false;
                
                TextPrompt.SetActive(true);
                TextPromptBG.SetActive(true);
                TextPrompt.GetComponent<Text>().text = goal.EndLVLMsg;
                //naciśnij spację by przejść do minigry
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player.hasControls = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else
            {
                TextPrompt.SetActive(true);
                TextPromptBG.SetActive(true);
                TextPrompt.GetComponent<Text>().text = "Not enough collectibles. (Press space to continue)";
                player.hasControls = false;
                player.speed = 0;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player.transform.position = new Vector3(player.lastCampfireCoordX, player.lastCampfireCoordY, 0);
                    TextPrompt.SetActive(false);
                    TextPromptBG.SetActive(false);
                    player.hasControls = true;
                    player.speed = 10;
                }
            }

        }

        //Check if next to a campfire
        foreach (Campfire campfire in campfires)
        {
            distanceToPlayer = Vector3.Distance(campfire.transform.position, player.transform.position);
            if (distanceToPlayer < maxDistanceToInteract)
            {
                playerInRange = true;
                player.lastCampfireCoordX = campfire.transform.position.x;
                player.lastCampfireCoordY = campfire.transform.position.y;
            }
        }
        
        //Check if next to a collectible
        foreach (Collectible collectible in collectibles)
        {
            if (!collectible.CheckIfCollected())
            {
                distanceToPlayer = Vector3.Distance(collectible.transform.position, player.transform.position);
                if (distanceToPlayer < maxDistanceToInteract)
                {
                    playerInRange = true;
                    player.hasControls = false;
                    collectible.activateSpirit();

                    TextPrompt.SetActive(true);
                    TextPromptBG.SetActive(true);
                    
                    TexttoPrompt = collectible.MyText;
                    TextPrompt.GetComponent<Text>().text = TexttoPrompt;
                    //Dialogue

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        player.hasControls = true;
                        isInSpiritWorld = false;
                        collectiblesCollected++;
                        collectible.CollectMe();
                        collectible.gameObject.SetActive(false);
                        TextPrompt.SetActive((false));
                        TextPromptBG.SetActive(false);
                    }
                }
            }
        }

        if (playerInRange)
            isInSpiritWorld = true;
        else
            isInSpiritWorld = false;

        if(isInSpiritWorld)
        {
            foreach (GameObject evilSpirit in evilSpirits)
            {
                evilSpirit.GetComponent<SpriteRenderer>().enabled=(true);
            }
            pathTileMap.gameObject.SetActive(true);
        }
        else
        {
            foreach (GameObject evilSpirit in evilSpirits)
            {
                evilSpirit.GetComponent<SpriteRenderer>().enabled=(false);
            }
            pathTileMap.gameObject.SetActive(false);
        }
        
        
    }
    private void FixedUpdate()
    {
        if (player.transform.position.y >= camera2ndBorder)
            camera.GetComponent<Transform>().position = new Vector3(0, 2 * cameraGoUpBy - cameraBaseY, -10);
        else if(player.transform.position.y >= camera1stBorder && player.transform.position.y < camera2ndBorder)
            camera.GetComponent<Transform>().position = new Vector3(0, cameraGoUpBy, -10);
        else if (player.transform.position.y < camera1stBorder)
            camera.GetComponent<Transform>().position = new Vector3(0, cameraBaseY, -10);

    }
    public void ChangeSpiritWorld(bool val)
    {
        isInSpiritWorld = val;
    }
    
}