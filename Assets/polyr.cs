using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class polyr : MonoBehaviour
{
    public GameObject o=new GameObject();
    // Start is called before the first frame update
    void Start()
    {
        Invoke("open", (25.8f-9.4f));
    }

    // Update is called once per frame
    public void open()
    {
        o.SetActive(false);
    }
    
}
