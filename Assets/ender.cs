using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ender : MonoBehaviour
{
    // Start is called before the first frame update
    //public AudioClip huffs;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            StartCoroutine(textor());
        }
        Invoke("huffline", 126);
        Invoke("scroller", 130);
    }
    IEnumerator textor()
    {
       
            for (int i = 0; i < 24; i++)
            {
            scroller();
            
            yield return new WaitForSeconds(5);
           
        }
       
    }

    void scroller()
    {
        this.gameObject.GetComponent<ScrollingText>().ActivateText();
    }

    void huffline()
    {
        //huffs.play();
       // Invoke("scroller", 3);
       // SceneManager.LoadScene("Main Menu");
    }
    
}
