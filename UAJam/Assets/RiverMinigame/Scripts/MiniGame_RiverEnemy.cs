using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class MiniGame_RiverEnemy : MonoBehaviour
{
    private float speed = 0.01f;
    [SerializeField] private Sprite[] Sprites;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            WrethGameManager.Instance.EndGameLose();
        }
        Destroy(this.gameObject);
        Debug.Log("collision");
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Sprites[Random.Range(0, 3)];

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * speed;
        
    }
}
