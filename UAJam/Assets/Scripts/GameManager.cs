using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    private bool isInSpiritWorld = false;

    [SerializeField] private GameObject camera;
    [SerializeField] private float cameraBaseY = 2f;
    [SerializeField] private float cameraGoUpBy = 11.5f;
    [SerializeField] private float camera1stBorder = 6f;
    [SerializeField] private float camera2ndBorder = 12f;
    
    
    [SerializeField] private Player player;
    [SerializeField] private List<Campfire> campfires;

    [SerializeField] private List<EvilSpirit> evilSpirits;
    
    [SerializeField] private List<Collectible> collectibles;
    private int collectiblesCollected = 0;
    private int collectiblesCount;

    [SerializeField] private Goal goal;

    [SerializeField] private Tilemap baseTileMap;
    [SerializeField] private Tilemap pathTileMap;
    [SerializeField] private Tilemap hidePathTileMap;

    [FormerlySerializedAs("maxDistanceFromCampfire")] 
    [SerializeField] double maxDistanceToInteract = 1d;

    // Start is called before the first frame update
    void Start()
    {
        collectiblesCount = collectibles.Count;
        foreach (EvilSpirit evilSpirit in evilSpirits)
        {
            evilSpirit.gameObject.GetComponent<EvilSpirit>().setVisibility(false);
        }
        baseTileMap.gameObject.SetActive(true);
        pathTileMap.gameObject.SetActive(false);
        hidePathTileMap.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.y >= camera2ndBorder)
            camera.GetComponent<Transform>().position = new Vector3(0, 2 * cameraGoUpBy - cameraBaseY, -10);
        else if(player.transform.position.y >= camera1stBorder && player.transform.position.y < camera2ndBorder)
            camera.GetComponent<Transform>().position = new Vector3(0, cameraGoUpBy, -10);
        else if (player.transform.position.y < camera1stBorder)
            camera.GetComponent<Transform>().position = new Vector3(0, cameraBaseY, -10);

        bool playerInRange = false;
        double distanceToPlayer;
        
        //Check if player hit monster
        if (player.hitMonster)
        {

            player.hasControls = false;
            isInSpiritWorld = true;

            if (Input.anyKey)
            {
                player.transform.position = new Vector3(player.lastCampfireCoordX, player.lastCampfireCoordY, 0);
                player.hasControls = true;
                player.hitMonster = false;
            }

        }
        
        //Check if next to the goal
        distanceToPlayer = Vector3.Distance(goal.transform.position, player.transform.position);
        if (distanceToPlayer < maxDistanceToInteract)
        {
            
            //Do canvas stuff here
            //Only freeze if collected everything
            if (collectiblesCollected == collectiblesCount)
            {
                player.speed = 0f;
                player.hasControls = false;

                //naciśnij spację by przejść do minigry
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player.hasControls = true;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            else
                Debug.Log("Not enough collectibles");
            
            
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

                    //Canvas stuff here
                    //Dialogue

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        player.hasControls = true;
                        isInSpiritWorld = false;
                        collectiblesCollected++;
                        collectible.CollectMe();
                        collectible.gameObject.SetActive(false);
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
            foreach (EvilSpirit evilSpirit in evilSpirits)
            {
                evilSpirit.setVisibility(true);
            }
            pathTileMap.gameObject.SetActive(true);
        }
        else
        {
            foreach (EvilSpirit evilSpirit in evilSpirits)
            {
                evilSpirit.setVisibility(false);
            }
            pathTileMap.gameObject.SetActive(false);
        }
        
    }
    public void ChangeSpiritWorld(bool val)
    {
        isInSpiritWorld = val;
    }
    
}