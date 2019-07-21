using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetection;
    public Collider colliderMe;
    public Collider colliderU;

    private void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //Physics.IgnoreCollision(colliderMe, colliderU);

        /*RaycastHit groundInfo = Physics.Raycast(groundDetection.position, Vector3.down, distance);

        if (groundInfo.collider == true)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                movingRight = true;
            }
        }*/
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Door")
        {
            print("door!");
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                movingRight = true;
            }
        }
    }
}
