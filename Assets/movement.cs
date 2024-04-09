using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movespeed;
    public Transform player;
    float hin;
    float vin;
    Vector3 direciton;
    Rigidbody rb;
    public float height;
    public LayerMask isground;
    bool grounded;
    public float groundd;
    public float jumpf;
    public float jumpc;
    public float airm;
    public bool jump;
    public float aird;
    public KeyCode key = KeyCode.Space;
    public bool bikini;
    /// <summary>
    public float maxv;
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        if(!bikini)
        jump = true;
        rb= GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded=Physics.Raycast(transform.position, Vector3.down, height*.5f+.2f,isground);
        //Debug.Log(grounded);
        MyInput();
        if (grounded)
        {
            rb.drag = groundd;
           // rb.drag = 0;
        }
        else
        {
            rb.drag = aird;
        }
        speedControl();
    }
    private void FixedUpdate()
    {
        movePlayer();
        /*if (Input.GetKey("w"))
        {
            rb.AddForce(new Vector3(0,0,);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(Vector3.right);

        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector3.left);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(Vector3.back);
        }*/
    }
    void MyInput()
    {
        hin = Input.GetAxisRaw("Horizontal");
        vin = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(key) && jump && grounded)
        {
            Jump();
            jump = false;
            //nameof
            Invoke("resetJump", jumpc);
        }

    }
    void movePlayer()
    {
        direciton=player.forward*vin+player.right*hin;
        //Time.deltaTime?
        if(grounded)
            rb.AddForce(direciton.normalized*movespeed*10f,ForceMode.VelocityChange);
        else
           rb.AddForce(direciton.normalized * movespeed * 10f*airm, ForceMode.VelocityChange);

    }
    void Jump()
    {
        rb.velocity=new Vector3(rb.velocity.x, 0,rb.velocity.z);
        rb.AddForce (transform.up*  jumpf,ForceMode.Impulse);

    }
    void resetJump()
    {
        jump = true;
    }
    void speedControl()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (flatvel.magnitude > maxv)
        {
            Vector3 limitedv = flatvel.normalized * maxv;
            rb.velocity = new Vector3(limitedv.x, rb.velocity.y, limitedv.z);
        }
    }
    
}
