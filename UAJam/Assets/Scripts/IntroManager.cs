using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private string SecondMessage;

    [SerializeField] private GameObject textField;

    private int numberOfTaps = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (numberOfTaps == 0)
                textField.GetComponent<Text>().text = SecondMessage;
            if (numberOfTaps == 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            numberOfTaps++;
        }
        
    }
}
