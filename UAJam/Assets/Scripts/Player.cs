using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> playerSprites;
    
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    
    public bool hasControls = true;
    public float speed = 10f; 
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasControls)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        
        Debug.Log(horizontal + ", " + vertical);

        if (horizontal == -1)
        {
            spriteRenderer.sprite = playerSprites[2];
            spriteRenderer.flipX = true;
        }
        else if (horizontal == 1)
        {
            spriteRenderer.sprite = playerSprites[2];
            spriteRenderer.flipX = false;
        } 
        else if (vertical == -1)
        {
            spriteRenderer.sprite = playerSprites[0];
            spriteRenderer.flipX = false;
        }
        else if (vertical == 1)
        {
            spriteRenderer.sprite = playerSprites[1];
            spriteRenderer.flipX = false;
        }
            
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit an evil spirit.");
        if (col.gameObject.CompareTag("Enemy"))
            this.rb.position = new Vector3(0, -4, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Boundary"))
        {
            float posX = rb.position.x;
            float newPosX = 0f;
            if (posX < 0)
                newPosX = 12;
            else if (posX > 0)
                newPosX = -11;
            
            float posY = this.rb.position.y;
            rb.position = new Vector3(newPosX, posY, 0);
            
        }
    }
}
