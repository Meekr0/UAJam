using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class CampfireJumpScripts : MonoBehaviour
{
    private Rigidbody2D thisRigidbody2D;
    private int JumpIndex = 0;
    private float startHeight;
    private bool grounded = true;
    private float timer;

    [SerializeField] private float JumpingModifier = 1;
    // Start is called before the first frame update
    void Start()
    {
        startHeight = this.transform.position.y;
        thisRigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisRigidbody2D.velocity.x < 0.001f & thisRigidbody2D.velocity.y < 0.001f &
            math.abs((this.transform.position.y - startHeight)) < 0.1f)
        {
            if (!grounded)
            {
                timer = Time.time;
                grounded = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
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
            JumpIndex++;
            grounded = false;
            MiniGameManagr.Instance.Score++;
            MiniGameManagr.Instance.Win();

        }
    }
}
