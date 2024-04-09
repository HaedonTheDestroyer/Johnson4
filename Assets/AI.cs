using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{
    public NavMeshAgent guy;
     Transform playerT;
    public float boundy,boundx,boundz;
    public float centerforce;
    public LayerMask isground, isplayer,isbitch;
    public Rigidbody body;
    public float power;
    public float radius;
    public float ups;
    public float bulletspeed;
    public float maxspeed;
    //patrol
    /*
    public Vector3 walkpoint;
    bool walkpointset;
    public float walkpointrange;*/
    //attack
    bool crammed = false;
    public float timebetweenattacks;
    bool alreadyattacked;
    //states
    public float sightrange, attackrange;
    public bool playerinsight;
    public bool playerinrange;
    public GameObject projectile;
    public bool meshon;

    private void Awake()
    {
        playerT=GameObject.Find("player").transform;
       if(meshon) guy = GetComponent<NavMeshAgent>();
    }
    void Patroling()
    {
        
    }
    void ChasePlayer()
    {
        if (meshon)
            guy.SetDestination(playerT.position);
    }
    void Attack()
    {
        transform.LookAt(playerT.position);
        if(!alreadyattacked )
        {
            alreadyattacked = true;
            
            Rigidbody rb=Instantiate(projectile,transform.position,Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce((playerT.position - transform.position).normalized * bulletspeed, ForceMode.Impulse);
            //nameof?
            Invoke("reseta",timebetweenattacks);
        }
    }
    void reseta()
    {
        alreadyattacked = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerinsight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //playerinsight=Physics.CheckSphere(transform.position, sightrange,isplayer);
        

        playerinrange = Physics.CheckSphere(transform.position, attackrange, isplayer);
        if (!playerinrange)
        {
            if (meshon)
                guy.SetDestination(playerT.position);
        }
        if (playerinsight&&!playerinrange)
        {
            ChasePlayer();
            Attack();
            
        }
        if (playerinsight && playerinrange)
        {
            if (meshon)
                guy.SetDestination(transform.position);
            
            Attack();
        }
        crammed = Physics.CheckSphere(transform.position, attackrange, isbitch);
        if (crammed)
        {
            //body.AddExplosionForce(power, new Vector3(transform.position.x, transform.position.y - 2, transform.position.x),radius, ups,ForceMode.Impulse) ;
            //transform.position=transform.position.normalized+transform.up*10;
            //guy.isStopped = true ;
        }
        if (transform.position.x>boundx||transform.position.z>boundz|| transform.position.x < -boundx || transform.position.z < -boundz)
        {
            body.AddForce(-transform.position.normalized*centerforce+new Vector3(0,3,0), ForceMode.Impulse) ;
        }
        speedControl();
        if (transform.position.y < -30)
        {
            Destroy(gameObject);
        }


    }
    public void getHit()
    {
        //Destroy(gameObject.GetComponent<NavMeshAgent>());
        Debug.Log("johnhit");
        Destroy(gameObject);
       

    }
    void speedControl()
    {
        //Vector3 flatvel = new Vector3(body.velocity.x, 0, body.velocity.z);
        if (body.velocity.magnitude > maxspeed)
        {
            //Vector3 limitedv = flatvel.normalized * maxspeed;
            body.velocity = body.velocity.normalized*maxspeed;
        }
    }
}
