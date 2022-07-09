using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private FriendlySpirit friendlySpirit;

    private bool hasBeenCollected;
    // Start is called before the first frame update
    void Start()
    {
        hasBeenCollected = false;
        friendlySpirit.gameObject.SetActive(false);
    }
    
    public void activateSpirit()
    {
        friendlySpirit.gameObject.SetActive(true);
    }

    public bool CheckIfCollected()
    {
        return this.hasBeenCollected;
    }

    public void CollectMe()
    {
        this.hasBeenCollected = true;
    }
    
}
