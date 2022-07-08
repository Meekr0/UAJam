using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    private bool isInSpiritWorld = false;

    [SerializeField] Tilemap baseTileMap;
    [SerializeField] Tilemap pathTileMap;
    [SerializeField] Tilemap hidePathTileMap;

    // Start is called before the first frame update
    void Start()
    {
        baseTileMap.gameObject.SetActive(true);
        pathTileMap.gameObject.SetActive(false);
        hidePathTileMap.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(isInSpiritWorld);
        if(isInSpiritWorld)
        {
            pathTileMap.gameObject.SetActive(true);
            hidePathTileMap.gameObject.SetActive(false);
        }
        else
        {
            pathTileMap.gameObject.SetActive(false);
            hidePathTileMap.gameObject.SetActive(true);
        }
    }

    public void changeSpiritWorld(bool val)
    {
        isInSpiritWorld = val;
    }
    
}
