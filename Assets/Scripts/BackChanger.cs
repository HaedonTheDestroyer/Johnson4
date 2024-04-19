using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackChanger : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public Camera l;
    public Color s;
    public Color t;
    public float returnspeed;
    // Start is called before the first frame update
    public void bang()
    {
        l.backgroundColor = s;

    }
    void Update()
    {

        l.backgroundColor = Color.Lerp(l.backgroundColor, t, Time.deltaTime * returnspeed);
    }
}
