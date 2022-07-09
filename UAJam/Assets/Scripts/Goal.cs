using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public string EndLVLMsg;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.goal = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
