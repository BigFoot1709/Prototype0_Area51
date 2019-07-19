using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float bulletSpeed = 10f;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            Destroy(gameObject);
        }

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0f, bulletSpeed * Time.deltaTime, 0f);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}
