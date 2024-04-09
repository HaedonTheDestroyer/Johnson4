using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CubeAi : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerT;
    bool alreadyattacked;
    bool alreadyattacked2;
    Target target;
    public GameObject projectile;
    public GameObject projectile2;
    public float bulletspeed;
    public float bulletspeed2;
    public float timebetweenattacks;
    public float timebetweenattacks2;
    public Material m1;
    public Material m2;
    public Material m3;
    public MeshRenderer cubeo;
    public float SPHEREUP;
    int lasthealth;
    public Rigidbody rb;
    public float centerforce;
    public float boundy, boundx, boundz;
    bool mad = false;
    public float speedm, ratem;
    public Rigidbody body;
    public LayerMask isbitch;
    void Start()
    {

        playerT = GameObject.Find("player").transform;
        target=GameObject.Find(name.ToString()).GetComponent<Target>();

    }
    void Update()
    {
        //playerinsight=Physics.CheckSphere(transform.position, sightrange,isplayer);

        if (transform.position.y < -30)
        {
            Destroy(gameObject);
        }
        Attack();
        if (target.health < 10)
        {
            cubeo.material = m1;
        }
        if (target.health < 7)
        {
            cubeo.material= m2;
        }
        if (target.health < 4)
        {
            cubeo.material = m3;
            if (!mad)
            {
                timebetweenattacks /= ratem;
                bulletspeed *= speedm;
                mad = true;
            }
        }
        if (transform.position.x > boundx || transform.position.z > boundz || transform.position.x < -boundx || transform.position.z < -boundz)
        {
            rb.AddForce(-transform.position.normalized * centerforce + new Vector3(0, 3, 0), ForceMode.Impulse);
        }
        if (Physics.CheckSphere(transform.position, 200, isbitch))
        {
            body.constraints = 0;
        }

    }
    
    void Attack()
    {
        //transform.LookAt(playerT.position);
        if (!alreadyattacked)
        {
            alreadyattacked = true;

            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce((playerT.position - transform.position).normalized * bulletspeed, ForceMode.Impulse);
            rb.AddTorque(Random.Range(-4, 4), Random.Range(-4, 4), Random.Range(-4, 4), ForceMode.Impulse);
            //nameof?
            Invoke("reseta", timebetweenattacks); 
        }
        if (!alreadyattacked2)
        {
            alreadyattacked2 = true;

            Rigidbody rb2 = Instantiate(projectile2, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb2.AddForce((playerT.position - transform.position).normalized * bulletspeed2, ForceMode.Impulse);
            rb2.AddForce(new Vector3(0,SPHEREUP,0), ForceMode.Impulse);
            //nameof?
            Invoke("reseta2", timebetweenattacks2);
        }
    }
    void reseta()
    {
        alreadyattacked=false;
    }
    void reseta2()
    {
        alreadyattacked2 = false;
    }
    // Update is called once per frame

}
