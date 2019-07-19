using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float bulletSpeed = -1f;
    //private float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = transform.position * bulletSpeed;
        /*timer += Time.deltaTime;
        if (timer > 2f)
        {
            Destroy(gameObject);
        }

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0f, bulletSpeed * Time.deltaTime, 0f);
        pos += transform.rotation * velocity;
        transform.position = pos;*/
    }
}
