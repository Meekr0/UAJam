using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrethGameManager : MonoBehaviour
{
    [SerializeField] private GameObject TextBG;
    [SerializeField] private GameObject Text;
    [SerializeField] private float TimeToSurvive = 30f;
    static public WrethGameManager Instance;

    private float Timer;
    // Start is called before the first frame update
    private void Awake()
    {
        Timer = TimeToSurvive;
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Debug.Log("Win");
        }

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
