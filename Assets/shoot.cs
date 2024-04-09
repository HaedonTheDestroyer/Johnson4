using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public ParticleSystem mf;
    public bool canshoot;
    public bool shotgun;
    public ParticleSystem mf2;
    bool hasshot;
    GameObject player;
    Rigidbody rb;
    public GameObject pistol;
    public GameObject shotgunObj;
    public float shotmult;
    public GameObject cam;
    public AudioSource shot1;
    public AudioSource shot2;
    public GameObject grah;
    public AudioSource theFarter3;
    public AudioSource theFarter4;
    Light lightc;
    public bool bikini;

    
        
     
    // Start is called before the first frame update
    void Start()
    {
        lightc = GameObject.Find("Directional Light").GetComponent<Light>();
        grah = GameObject.Find("Image");
        grah.SetActive(false);
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("player");
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            if (shotgun)
            {
                theFarter3.Play();
                grah.SetActive(true);
                lightc.color = Color.black;
                Invoke("resetgrah", .5f);
            }
            else
            {
                shoot1();
            }
             
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (shotgun)
            {
                shoot1();
            }
            else
            {
                theFarter4.Play();
                grah.SetActive(true);
                lightc.color=Color.black;
                Invoke("resetgrah", .5f);
            }
        }




    }
    void resetgrah()
    {
        grah.SetActive(false);
    }
    public void primeshot()
    {
        shotgun = true;
        hasshot = false;
        shotgunObj.SetActive(true);
        pistol.SetActive(false);
        //shoot1();
        Invoke("switcher", .3f);
    }
    void switcher()
    {
        
            shotgunObj.SetActive(false );
            pistol.SetActive(true);
            shotgun=false;
            hasshot = true; ;
        
    }
    public void ShootOn()
    {
        canshoot=true;

        Invoke("ShootOff", .2f);
    }
    public void ShootOff()
    {
        canshoot = false;
    }
    void shoot1()
    {
        if (shotgun&&!hasshot)
        {
            Debug.Log("shotgun shit");
            shot2.Play();
            if (mf2!=null)
                mf2.Play();
            //force system might be jank, check rotation poition normalize and negative.
            //rb.AddRelativeForce(new Vector3(0, 3, -20));
            if (!bikini)
            {
                rb.AddForce((-((cam.transform.rotation * Vector3.back).normalized)) * shotmult, ForceMode.Impulse);
            }
            else
            {
                Vector3 mainvec = - ((cam.transform.rotation * Vector3.back).normalized);
                rb.AddForce(new Vector3(mainvec.x,0,mainvec.z)*shotmult, ForceMode.Impulse);
            }
            Debug.Log("shotgun shit2");
            hasshot = true;
            shotgun=false;
        }else if (canshoot&&!shotgun){
            if (mf != null)
            {
                mf.Play();
                mf.Play();
                shot1.Play();
            }
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform);
                
                Target t = hit.transform.GetComponent<Target>();
                if (t != null)
                {
                    Debug.Log("johnhit1");
                    t.Invoke("getHit", .1f);
                }
                //print(hit.collider.name);
            }
        }
        else
        {

        }
    }

}
