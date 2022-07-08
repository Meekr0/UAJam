using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isInSpiritWorld = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(isInSpiritWorld);
    }

    public void changeSpiritWorld(bool val)
    {
        isInSpiritWorld = val;
    }
    
}
