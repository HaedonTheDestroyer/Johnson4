using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class bulletcollision : MonoBehaviour
{
    // Start is called before the first frame update
    Light lightc;
    public int destroyer;
    public bool killer = true;
    GameObject manager;
    GameManager gameManager;
    
    void Start()
    {
        manager = GameObject.Find("Manager");
        if (manager.GetComponent<GameManager>().playerHealth > 0)
        {
            lightc = GameObject.Find("Directional Light").GetComponent<Light>();
        }
        Invoke("bulletdie",destroyer);
        gameManager=manager.GetComponent<GameManager>();
    }
    void bulletdie()
    {

        
        Destroy(gameObject);

    }
    //public Light l;




    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (killer&&collision.gameObject.tag=="Player")
        {
           
            if (manager.GetComponent<GameManager>().playerHealth > 0)
            {
                lightc.color = Color.red;
                lightc.intensity = 2;
            }
            gameManager.Invoke("phit",0);
        }
        
    }
}
