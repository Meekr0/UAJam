using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawPointMover : MonoBehaviour
{
    [SerializeField] private GameObject[] Points;
    [SerializeField] private Sprite[] Sprites;
    [SerializeField] private GameObject Obstacle;
    [SerializeField] private float CoolDown = 2;
    private float startCooldown;
    [SerializeField] private float speed;
    private float timer = 0;

    private bool isUp = false;
    // Start is called before the first frame update
    void Start()
    {
        startCooldown = CoolDown;
        this.transform.position = Points[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUp)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, Points[0].transform.position, 1);
            if (Vector3.Distance(transform.position, Points[0].transform.position) < 0.01)
            {
                isUp = false;
            }
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(transform.position, Points[1].transform.position, 1);
            if (Vector3.Distance(transform.position, Points[1].transform.position) < 0.01)
            {
                isUp = true;
            }
        }
        spawner();
    }

    private void spawner()
    {
        timer += Time.deltaTime;
        if ( timer > CoolDown)
        {
            CoolDown += startCooldown;
            var NewObstacle = Instantiate(Obstacle, this.transform.position + new Vector3(0,0,-1), Quaternion.identity);
        }
        
    }
}
