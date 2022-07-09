using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    
    public bool hasControls = true;
    public float speed = 10f; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate()
    {
        if(hasControls)
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("adssad");
        if (col.gameObject.tag == "Enemy")
            this.rb.position = new Vector3(0, -4, 0);
    }
}
