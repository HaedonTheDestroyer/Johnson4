using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmOb : MonoBehaviour
{
    // Start is called before the first frame update
    Light lightc;
    public int destroyer;
    public bool killer = true;
    GameObject manager;
    GameManager gameManager;
    public int dmg;
    void Start()
    {
        manager = GameObject.Find("Manager");
        if (manager.GetComponent<GameManager>().playerHealth > 0)
        {
            lightc = GameObject.Find("Directional Light").GetComponent<Light>();
        }
        //Invoke("bulletdie", destroyer);
        gameManager = manager.GetComponent<GameManager>();
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
        if (killer && collision.gameObject.tag == "Player")
        {

            if (manager.GetComponent<GameManager>().playerHealth > 0)
            {
                lightc.color = Color.red;
                lightc.intensity = 2;
            }
            gameManager.Invoke("phit", 0);
        }

    }
   
    
    public float attackCooldown;

    float _lastAttackTime;

    private void OnCollisionStay(Collision collision)
    {
        // Abort if we already attacked recently.
        if (Time.time - _lastAttackTime < attackCooldown) return;

        // CompareTag is cheaper than .tag ==
        if (collision.gameObject.tag=="Player")
        {
            if (manager.GetComponent<GameManager>().playerHealth > 0)
            {
                lightc.color = Color.red;
                lightc.intensity = 2;
            }
            for (int i = 0; i < dmg; i++)
            {
                gameManager.Invoke("phit", 0);
            }

            // Remember that we recently attacked.
            _lastAttackTime = Time.time;
        }
    }
}
