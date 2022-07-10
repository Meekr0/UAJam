using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WrethGameManager : MonoBehaviour
{
    [SerializeField] private string GameLostString;
    [SerializeField] private string GameWinString;
    [SerializeField] private GameObject Clock;
    [SerializeField] private GameObject TextBG;
    [SerializeField] private GameObject Text;
    [SerializeField] private float TimeToSurvive = 30f;
    static public WrethGameManager Instance;
    [SerializeField] private string EntryText;
    private bool lost = false;
    private bool staring = true;

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
        Text.SetActive(true);
        TextBG.SetActive(true);
        Text.GetComponent<Text>().text = EntryText;



    }

    // Update is called once per frame
    void Update()
    {
        if (staring & Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
            Text.SetActive(false);
            TextBG.SetActive(false);
            staring = false;
        }
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            EndGameWin();
            Timer = 0;
        }
        int rounded = Convert.ToInt32(TimeToSurvive);
        TimeToSurvive -= Time.deltaTime;
        Clock.GetComponent<Text>().text = rounded.ToString();
        if (Input.GetKey(KeyCode.Space) & lost)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        }
    }

    public void EndGameWin()
    {
        Debug.Log("Win");
        Time.timeScale = 0;
        Text.SetActive(true);
        TextBG.SetActive(true);
        Text.GetComponent<Text>().text = GameWinString;
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void EndGameLose()
    {
        Debug.Log("Lost");
        Time.timeScale = 0;
        lost = true;
        Text.SetActive(true);
        TextBG.SetActive(true);
        Text.GetComponent<Text>().text = GameLostString;
        Debug.Log("Lost");
    }
    
}
