using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endblock : MonoBehaviour
{
    bool e1, e2;
    public bool unlcokcer = true;
    public bool fart;
    private MeshRenderer meshRenderer;
    public bool math;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        e1=GameObject.FindGameObjectWithTag("Enemy")==null;
        //e2= GameObject.FindGameObjectWithTag("IceCube") == null;
        if(e1)
        {
            if (fart)
            {
                if (Time.timeSinceLevelLoad > 30)
                {
                    meshRenderer.enabled = true;
                }
                else
                {
                    meshRenderer.enabled = false;
                }
            }
            else
            {
                if (!math)
                {
                    meshRenderer.enabled = true;
                }
                else
                {
                    //check for math being done later
                    meshRenderer.enabled = false;
                }
            }

        }
        else
        {
            
                meshRenderer.enabled = false;
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(e1)
        {
            if(unlcokcer) 
                PlayerPrefs.SetInt("levels",SceneManager.GetActiveScene().buildIndex+1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
