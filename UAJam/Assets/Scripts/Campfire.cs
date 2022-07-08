using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{

    public Player Player;
    public GameManager GameManager;
    double distanceToPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        distanceToPlayer = Vector3.Distance(this.transform.position, Player.transform.position);
        if (distanceToPlayer <= 1)
        {
            Debug.Log("Dystans = " + distanceToPlayer);
            GameManager.changeSpiritWorld(true);
        }
        else
        {
            GameManager.changeSpiritWorld(false);
        }
        
    }
}
