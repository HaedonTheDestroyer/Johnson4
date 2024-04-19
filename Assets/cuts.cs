using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class cuts : MonoBehaviour
{
    public TextMeshProUGUI itemInfoText;
    public GameObject g;
    public Color c1, c2;

    // Start is called before the first frame update
    void Start()
    {
       
        Invoke("go",3);
        
        Invoke("go", 7);
        
        Invoke("go", 9);
        
        Invoke("go", 15);
      
        Invoke("go", 18);
        Invoke("nexter", 23);

    }

    // Update is called once per frame
    public void go()
    {
        g.GetComponent<ScrollingText>().ActivateText();
    }
    public void nexter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
