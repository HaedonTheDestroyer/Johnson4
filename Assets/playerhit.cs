using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Light l;
    public Color johnsonc;
    //public float flashc;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void phit()
    {
        l.color = johnsonc;
    }
}
