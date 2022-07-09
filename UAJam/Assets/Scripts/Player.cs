using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> playerSprites;
    private Animator animator;
    
    
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
        animator = GetComponent<Animator>();
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

        if (horizontal < 0)
        {
            spriteRenderer.sprite = playerSprites[2];
            //spriteRenderer.flipX = true;
            if(!isAnimPlaying("playerSideAnimRev"))
                animator.Play("playerSideAnimRev", 0, 0f);
        }
        else if (horizontal > 0)
        {
            spriteRenderer.sprite = playerSprites[2];
            spriteRenderer.flipX = false;
            if(!isAnimPlaying("playerSideAnim"))
                animator.Play("playerSideAnim", 0, 0f);
        } 
        else if (vertical < 0)
        {
            spriteRenderer.sprite = playerSprites[0];
            spriteRenderer.flipX = false;
            if(!isAnimPlaying("playerFrontAnim"))
                animator.Play("playerFrontAnim", 0, 0f);
        }
        else if (vertical > 0)
        {
            spriteRenderer.sprite = playerSprites[1];
            spriteRenderer.flipX = false;
            if(!isAnimPlaying("playerBackAnim"))
                animator.Play("playerBackAnim", 0, 0f);
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

    private bool isAnimPlaying(string animName)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(animName) &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        return false;
    }
    
}
