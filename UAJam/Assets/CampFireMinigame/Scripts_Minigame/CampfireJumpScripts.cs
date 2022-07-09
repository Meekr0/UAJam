using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CampfireJumpScripts : MonoBehaviour
{
    private Rigidbody2D thisRigidbody2D;
    private int JumpIndex = 0;
    private float startHeight;
    private bool grounded = true;
    private float timer;
    [SerializeField] private Sprite Stand;
    [SerializeField] private Sprite Jump;

    [SerializeField] private float JumpingModifier = 1;
    // Start is called before the first frame update
    void Start()
    {
        startHeight = this.transform.position.y;
        thisRigidbody2D = this.GetComponent<Rigidbody2D>();
        this.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (thisRigidbody2D.velocity.x < 0.001f & thisRigidbody2D.velocity.y < 0.001f &
            math.abs((this.transform.position.y - startHeight)) < 0.1f)
        {
            if (grounded)
            {
                this.GetComponent<SpriteRenderer>().sprite = Stand;
                timer = Time.time;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) & MiniGameManagr.Instance.started )
        {
            Jumping();
        }

    }

    void Jumping()
    {
        if (thisRigidbody2D.velocity.x < 0.001f & thisRigidbody2D.velocity.y < 0.001f & math.abs((this.transform.position.y - startHeight))<0.1f)
        {
            if (JumpIndex % 2 == 0)
                thisRigidbody2D.AddForce(transform.up * JumpingModifier + transform.right * JumpingModifier);
            else
                thisRigidbody2D.AddForce(transform.up * JumpingModifier - transform.right * JumpingModifier);
            grounded = false;
            MiniGameManagr.Instance.Score++;
            MiniGameManagr.Instance.Win();
            if (JumpIndex !=0)
                this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
            JumpIndex++;
            this.GetComponent<Animator>().enabled = true;

        }
    }

    private void DisableAnimator()
    {
        this.GetComponent<Animator>().enabled = false;
    }
}
