using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    public Light l;
    public float returnspeed;
    public Color defaultcolor;
    // Start is called before the first frame update
    public void bang()
    {
        l.intensity = 4;
       
    }
    void Update()
    {

        l.intensity = Mathf.Lerp(l.intensity, 1, Time.deltaTime * returnspeed);
        l.color = Color.Lerp(l.color, defaultcolor, Time.deltaTime * returnspeed);
    }
}
