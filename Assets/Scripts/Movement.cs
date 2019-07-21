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
    public bool gunRight;
    public bool gunLeft;
    AudioSource source;
    public AudioClip walking;
    public AudioClip openDoor;
    public bool isWalking;
    private float timer;
    public float walkTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        source = Camera.main.GetComponent<AudioSource>();
        isWalking = false;
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
            gunLeft = false;
            gunRight = true;
            isWalking = true;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 moveLeft = this.transform.position;
            moveLeft.x = moveLeft.x - speed;
            this.transform.position = moveLeft;
            gunRight = false;
            gunLeft = true;
            isWalking = true;
        }
        else
        {
            isWalking = false;
            source.loop = isWalking;
        }

        if (isWalking == true)
        {

            //Invoke("Walking", 0f);
            //source.clip = walking;
            
        }

        //isWalking = false;
    }

    // collision to detect player input at doors

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Door" && Input.GetKeyDown(KeyCode.E))
        {
            //rotate door to look open instead of destroy, Destroy below is temporary!
            Destroy(collision.gameObject);
            source.PlayOneShot(openDoor);
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

    /*void Walking()
    {
        timer += Time.deltaTime;
        if (timer >= walkTime)
        {
            source.PlayOneShot(walking);
            timer = 0f;
        }
    }*/
}
