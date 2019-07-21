using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Cage : MonoBehaviour
{
    public GameObject alien;
    public Sprite openCage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            alien.GetComponent<AlienFollow>().enabled = true;
            GetComponent<SpriteRenderer>().sprite = openCage;
        }
    }
}
