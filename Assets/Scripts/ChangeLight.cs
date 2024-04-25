using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    public Light l;
    public float returnspeed;
    public Color defaultcolor;
    public Color changecolor;
    public bool changer;
    public int intensity;
    // Start is called before the first frame update
    public void bang()
    {
        l.intensity = intensity;
        if ( changer )
        l.color = changecolor;
       
    }
    void Update()
    {

        l.intensity = Mathf.Lerp(l.intensity, 1, Time.deltaTime * returnspeed);
        l.color = Color.Lerp(l.color, defaultcolor, Time.deltaTime * returnspeed);
    }
}