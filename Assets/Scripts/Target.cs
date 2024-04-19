using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public void getHit()
    {
        //Destroy(gameObject.GetComponent<NavMeshAgent>());
        health -= 1;
        if (health <= 0)
        {
            Die();
        }
        

    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
