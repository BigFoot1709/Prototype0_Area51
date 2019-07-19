using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CloneDraugrBehaviour : MonoBehaviour
{

    public float wanderDistance;
    public float timeBeforeWanderAgain;
    Transform Destination;
    NavMeshAgent DraugrBrain;
    float frameTimer;
    Animator anim;
    GameObject player;
    public GameObject DeadDragr;
    public GameObject HealthDrop;

    public AudioSource SoundSource;
    public AudioClip AlertClip;

    int randomChanceToSpawn;

    //public GameObject Dialogue;


    // Use this for initialization
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        DraugrBrain = GetComponent<NavMeshAgent>();
        frameTimer = timeBeforeWanderAgain;
        player = GameObject.FindGameObjectWithTag("player");

        SoundSource = GetComponent<AudioSource>();

        SoundSource.clip = AlertClip;

    }

    // Update is called once per frame
    void Update()
    {
        frameTimer += Time.deltaTime;

        if (frameTimer >= timeBeforeWanderAgain)
        {
            Vector3 Pos = RandomNavigationRadius(transform.position, wanderDistance, -1);
            DraugrBrain.SetDestination(Pos);
            frameTimer = 0f;
        }
        if (DraugrBrain.velocity.magnitude >= 0.1f)
        {
            anim.SetFloat("MoveSpeed", 0.2f);
        }
        if (DraugrBrain.velocity.magnitude <= 0.1f)
        {
            anim.SetFloat("MoveSpeed", 0.0f);

        }

    }

    Vector3 RandomNavigationRadius(Vector3 startPt, float distance, int layermask)
    {

        Vector3 randomPos = Random.insideUnitSphere * distance;

        randomPos += startPt;

        NavMeshHit navigationHit;

        NavMesh.SamplePosition(randomPos, out navigationHit, distance, layermask);

        return navigationHit.position;

    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.GetComponent<Collider>().tag == "player")
        {
            SoundSource.pitch = Random.Range(1f, 1.3f);

            SoundSource.PlayOneShot(AlertClip);
        }
    }
    private void OnTriggerStay(Collider Other)
    {
        if (Other.GetComponent<Collider>().tag == "player")
        {

            DraugrBrain.SetDestination(player.transform.position);
        }
    }
   

    public void Death()
    {
        Instantiate(DeadDragr, this.transform.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f));

        randomChanceToSpawn = Random.Range(0, 6);
        if (randomChanceToSpawn >= 3)
        {

            Instantiate(HealthDrop, this.transform.position, Quaternion.identity);

        }

        //Dialogue.GetComponent<DialoguePt2>().enabled = false;
        //Dialogue.GetComponent<DialoguePt3>().enabled = true;

        //if (Dialogue.GetComponent<DialoguePt3>().index == 19)
        //{
        //    Dialogue.GetComponent<DialoguePt3>().enabled = false;

        //}
        Destroy(this.gameObject);
    }

}

