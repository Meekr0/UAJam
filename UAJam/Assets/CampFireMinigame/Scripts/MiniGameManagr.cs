using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManagr : MonoBehaviour
{
    [SerializeField] GameObject ScoreField;
    [SerializeField] private GameObject TimeField;
    [SerializeField] private float TimeLimit = 60;
    [SerializeField] private int ScoreToWin = 20;
    [SerializeField] private GameObject tutorial;
    public int Score = 0;
   public static MiniGameManagr Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        Time.timeScale = 0f;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ResumeGame();
        ScoreField.GetComponent<Text>().text =Score.ToString();
        int rounded = Convert.ToInt32(TimeLimit);
        TimeLimit -= Time.deltaTime;
        TimeField.GetComponent<Text>().text = rounded.ToString();
    }

    public void Win()
    {
        if (Score >= ScoreToWin)
        {
            Debug.Log("Win");
        }
    }

    private void ResumeGame()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            Time.timeScale = 1f;
            Destroy(tutorial.gameObject);
        }
    }
    
}
