using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public GameObject bulletPrefab2;
    public GameObject bulletSpawn2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int enemyLayer = 1 << 9;
        enemyLayer = ~enemyLayer;

        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 3f, enemyLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            if (hit.collider.gameObject.tag == "Player")
            {
                GetComponent<Patrol>().enabled = false;
                if (GetComponent<Patrol>().movingRight == true)
                {
                    Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                }
                else if(GetComponent<Patrol>().movingRight == false)
                {
                    Instantiate(bulletPrefab2, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
            Debug.Log("Did not Hit");
            GetComponent<Patrol>().enabled = true;
        }
    }
}
