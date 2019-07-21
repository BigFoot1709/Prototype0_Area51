using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 2f;
    public Rigidbody rgbBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rgbBullet.velocity = transform.position * speed;
        rgbBullet.AddForce(new Vector3(-1f, 0f, 0f), ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Door")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "DestructWall")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
