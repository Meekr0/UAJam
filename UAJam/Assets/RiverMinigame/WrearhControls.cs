using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WrearhControls : MonoBehaviour
{
    [SerializeField] private float MovementDelta = 2;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float Maxy;
    Vector3 NewPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            NewPosition = this.transform.position - Vector3.down*MovementDelta;
        }
        if (Input.GetKey(KeyCode.S))
        {
           NewPosition = this.transform.position + Vector3.down*MovementDelta;
        }
        if (Input.GetKey(KeyCode.A))
            NewPosition = this.transform.position + Vector3.left*MovementDelta;
        if (Input.GetKey(KeyCode.D))
            NewPosition = this.transform.position - Vector3.left*MovementDelta;
        if (NewPosition.x > maxX)
        {
            NewPosition.x = maxX;
        }

        if (NewPosition.x < minX)
            NewPosition.x = minX;
        if (NewPosition.y < minY)
            NewPosition.y = minY;
        if (NewPosition.x > maxX)
            NewPosition.x = maxX;
        if (NewPosition.y > Maxy)
            NewPosition.y = Maxy;
        NewPosition.z = -1;
        this.transform.position = NewPosition;

    }
}