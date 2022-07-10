using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private FriendlySpirit friendlySpirit;
    [SerializeField] public string MyText;

    private bool hasBeenCollected;
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.collectibles.Add(this);
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
