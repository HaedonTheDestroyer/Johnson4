using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject big;
    public GameObject Cube;
    public GameObject player;
    public Beat beater;
    public endblock endBlock;
    

    bool dropo;
    public float dropspeed;
    void Start()
    {
        endBlock.fart = true;
        beater.spawnend = 100;
        beater.spawntime = 19;
        dropo = true;
        Invoke("spawner", 19);
        //player.GetComponent<Rigidbody>().AddForce(0, -600, 0, ForceMode.Impulse);
        Invoke("dropper", 7);
        

    }
    void dropper()
    {
        dropo = false;
    }
    void drop()
    {
        player.GetComponent<Rigidbody>().AddForce(0, -dropspeed*Time.deltaTime, 0, ForceMode.Impulse);
    }
    private void Update()
    {
        if (dropo)
        {
            drop();
        }
    }

    // Update is called once per frame
    void spawner()
    {
        
        /*Component[] enemy = big.GetComponentsInChildren(typeof(Transform), true);
        foreach (Transform x in enemy)
        {
            x.GetComponent<GameObject>().SetActive(true);
        }*/
        Instantiate(Cube, new Vector3(Random.Range(-100, 100), 1.5f, Random.Range(-100, 100)), new Quaternion());
        Instantiate(Cube, new Vector3(Random.Range(-100, 100), 1.5f, Random.Range(-100, 100)), new Quaternion());
        Instantiate(Cube, new Vector3(Random.Range(-100, 100), 1.5f, Random.Range(-100, 100)), new Quaternion());
        Instantiate(Cube, new Vector3(Random.Range(-100, 100), 1.5f, Random.Range(-100, 100)), new Quaternion());
        Instantiate(Cube, new Vector3(Random.Range(-100, 100), 1.5f, Random.Range(-100, 100)), new Quaternion());
        Instantiate(Cube, new Vector3(Random.Range(-100, 100), 1.5f, Random.Range(-100, 100)), new Quaternion());
    }
}
