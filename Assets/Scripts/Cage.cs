using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Cage : MonoBehaviour
{
    public GameObject alien;
    public Sprite openCage;
    AudioSource source;
    public AudioClip savedLives;
    // Start is called before the first frame update
    void Start()
    {
        source = Camera.main.GetComponent<AudioSource>();
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
            GetComponentInChildren<SpriteRenderer>().sprite = openCage;
            source.PlayOneShot(savedLives);
        }
    }
}
