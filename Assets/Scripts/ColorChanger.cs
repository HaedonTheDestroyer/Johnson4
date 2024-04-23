using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Material m1;
    public Material m2;
    public MeshRenderer m3;
    public float bpm;
    public int steps;
    public void color1()
    {
        m3.material=m1;
        Invoke("color2", .1f);

    }
    public void color2() { 
        m3.material=m2;
    
    }
}
