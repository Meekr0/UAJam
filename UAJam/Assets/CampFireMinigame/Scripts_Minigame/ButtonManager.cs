using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager :  MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject TextField;
    [SerializeField] private string ObjectDescyption;


    private RectTransform rectTransform;
    

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exited");
    }
    private void Awake()
    {
        TextField.GetComponent<Text>().text = ObjectDescyption;
    }
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered");
        
    }
}
