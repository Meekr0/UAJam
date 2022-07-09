using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSpirit : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void setVisibility(bool val)
    {
        this.spriteRenderer.enabled = val;
    }
    
}
