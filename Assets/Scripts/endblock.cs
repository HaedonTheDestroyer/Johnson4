using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endblock : MonoBehaviour
{
    bool e1, e2;
    public bool unlcokcer = true;
    public bool maze;
    public bool fart;
    // Start is called before the first frame update
    void Start()
    {
        
        
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!maze)
        {
            e1 = GameObject.FindGameObjectWithTag("Enemy") == null;
            //e2= GameObject.FindGameObjectWithTag("IceCube") == null;
            if (e1)
            {
                if (fart)
                {
                    if (Time.timeSinceLevelLoad > 30)
                    {
                        gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else
                    {
                        gameObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
                else
                {
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                }

            }
            else
            {

                gameObject.GetComponent<MeshRenderer>().enabled = false;

            }
        }
        else{
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(e1)
        {
            if(unlcokcer) 
                PlayerPrefs.SetInt("levels",SceneManager.GetActiveScene().buildIndex+1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if (maze)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
