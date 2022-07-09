using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSpirit : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void setVisibility(bool val)
    {
        spriteRenderer.enabled = val;
    }
    
}
