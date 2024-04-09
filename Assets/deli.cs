using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class deli : MonoBehaviour
{
    // Start is called before the first frame update
    public Beat beater;
    bool e1;
    public int length;
    void Start()
    {
        Invoke("check", 9);
    }
    void check()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            e1 = true;
            beater.randomon();
            beater.spawnend = Time.timeSinceLevelLoad + length;
        }
        else
        {
            Invoke("check", 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            e1 = true;
            beater.randomon();
            beater.spawnend = Time.time + length;
        }*/
    }
}
