using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
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
        //rgbBullet.velocity = transform.position * -speed;
        rgbBullet.AddForce(new Vector3(1f, 0f, 0f), ForceMode.Force);
    }
}
