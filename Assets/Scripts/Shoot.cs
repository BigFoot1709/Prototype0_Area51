using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //private float timer;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GetComponent<Movement>().gunRight == true) {
                Instantiate(bulletPrefab1, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
            }

            if (GetComponent<Movement>().gunLeft == true) {
                Instantiate(bulletPrefab2, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
            }
        }

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
