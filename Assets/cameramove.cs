using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.UIElements;

public class cameramove : MonoBehaviour
{
    public float xsens;
    public float ysens;
    public Transform player;
    public Transform cam;
    
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //should be "mouse X"
        float x=Input.GetAxisRaw("Mouse X")*Time.deltaTime*xsens;
        float y=Input.GetAxisRaw("Mouse Y")*Time.deltaTime*ysens;
        yRotation += x;
        xRotation -= y;
        xRotation=Mathf.Clamp(xRotation, -90, 90);
        //yRotation=Mathf.Clamp(yRotation, -90, 90);
        //cam.rotation=Quaternion.Euler(xRotation,yRotation,0);
        //player.rotation= Quaternion.Euler(0, yRotation, 0);
        transform.rotation=Quaternion.Euler(xRotation, yRotation, 0);
        player.rotation=Quaternion.Euler(0, yRotation, 0);
    }
}
