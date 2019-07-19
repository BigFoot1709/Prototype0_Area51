using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private float speed = 0.2f;

    public GameObject lift1;
    public GameObject lift2;
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Basic side-to-side player movement

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 moveRight = this.transform.position;
            moveRight.x = moveRight.x + speed;
            this.transform.position = moveRight;

        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 moveLeft = this.transform.position;
            moveLeft.x = moveLeft.x - speed;
            this.transform.position = moveLeft;
           // this.transform.Rotate(0f, 180f, 0f);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }
    }

    // collision to detect player input at doors

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Door" && Input.GetKeyDown(KeyCode.E))
        {
            //rotate door to look open instead of destroy, Destroy below is temporary!
            Destroy(collision.gameObject);
        }
    }

    //Trigger to detect player input at elevators 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Lift1" && Input.GetKeyDown(KeyCode.E))
        {
            this.transform.position = lift2.transform.position;
        } else if (other.gameObject.tag == "Lift2" && Input.GetKeyDown(KeyCode.E))
        {
            this.transform.position = lift1.transform.position;
        }
    }
}
