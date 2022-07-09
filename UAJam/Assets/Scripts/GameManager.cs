using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    private bool isInSpiritWorld = false;

    [SerializeField] private GameObject camera;
    [SerializeField] private float cameraBump = 11.5f;
    
    [SerializeField] private Player player;
    [SerializeField] private List<Campfire> campfires;

    [SerializeField] private List<EvilSpirit> evilSpirits;
    
    [SerializeField] private List<Collectible> collectibles;
    private int collectiblesCollected = 0;

    [SerializeField] private Tilemap baseTileMap;
    [SerializeField] private Tilemap pathTileMap;
    [SerializeField] private Tilemap hidePathTileMap;

    [SerializeField] double maxDistanceFromCampfire = 1d;

    // Start is called before the first frame update
    void Start()
    {
        foreach (EvilSpirit evilSpirit in evilSpirits)
        {
            evilSpirit.setVisibility(false);
        }
        baseTileMap.gameObject.SetActive(true);
        pathTileMap.gameObject.SetActive(false);
        hidePathTileMap.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(player.transform.position.y >= 6)
            camera.GetComponent<Transform>().position = new Vector3(0, cameraBump, -10);
        if (player.transform.position.y < 6)
            camera.GetComponent<Transform>().position = new Vector3(0, 0, -10);

        bool playerInRange = false;
        foreach (Campfire campfire in campfires)
        {
            double distanceToPlayer = Vector3.Distance(campfire.transform.position, player.transform.position);
            if(distanceToPlayer < maxDistanceFromCampfire)
                playerInRange = true;
        }

        foreach (Collectible collectible in collectibles)
        {
            if (!collectible.CheckIfCollected())
            {
                double distanceToPlayer = Vector3.Distance(collectible.transform.position, player.transform.position);
                if (distanceToPlayer < maxDistanceFromCampfire)
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

        Debug.Log(isInSpiritWorld);
        
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