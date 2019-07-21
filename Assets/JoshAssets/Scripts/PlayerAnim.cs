using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAnim : MonoBehaviour
{
    public Animator playerAnimation;
    public SpriteRenderer playerSprite;
    AudioSource source;
    public AudioClip walking;
    // Start is called before the first frame update
    void Start()
    {
        source = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D))) {

            playerAnimation.SetBool("isWalking", true);
            if (Input.GetKeyDown(KeyCode.A))
                playerSprite.flipX = true;
            else if(Input.GetKeyDown(KeyCode.D))
                playerSprite.flipX = false;
            source.loop = playerAnimation;
            source.Play();
            source.clip = walking;
        }
        if ((Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.D)))
        {
            playerAnimation.SetBool("isWalking", false);
            source.loop = playerAnimation;
            source.Stop();
        }
    }
}
