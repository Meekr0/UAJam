using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrethGameManager : MonoBehaviour
{
    [SerializeField] private float TimeToSurvive;
    static public WrethGameManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGameWin()
    {
        Debug.Log("Win");
    }

    public void EndGameLose()
    {
        Debug.Log("Lost");
    }
    
}
