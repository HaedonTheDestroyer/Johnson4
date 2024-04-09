using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject text;
     bool canleave;
    void Start()
    {
        Invoke("one", 2);
        Invoke("two", 7);
    }
    void one()
    {
        text.GetComponent<TextMeshProUGUI>().text = "Killing a person through dreams is uncharted territory";
    }
    void two()
    {
        canleave = true;
        text.GetComponent<TextMeshProUGUI>().text = "You navigated it excellently";
    }

    // Update is called once per frame
    private void Update()
    {
        if (canleave)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
