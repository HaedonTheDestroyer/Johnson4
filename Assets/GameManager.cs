using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public int playerHealth;
    GameObject bar;
    movement m;
    bool gameEnd;
    GameObject l;
    AudioSource a;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player = GameObject.Find("player");
        bar = GameObject.Find("bar");
        m=player.GetComponent<movement>();
        gameEnd = false;
        bar.GetComponent<Slider>().value = playerHealth;
        l = GameObject.Find("Directional Light");
        a=player.GetComponent<AudioSource>();
    }
    public void endGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void phit()
    {
        playerHealth--;
        bar.GetComponent<Slider>().value = playerHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (playerHealth <= 0&&!gameEnd) {
            a.enabled = false;
            l.SetActive(false);
            gameEnd = true;
            m.enabled = false;
            Invoke("endGame", 2);
        
        }
        if (player.transform.position.y<-20&&!gameEnd)
        {
            a.enabled = false;
            l.SetActive(false) ;
            gameEnd = true;
            m.enabled = false;
            Invoke("endGame", .5f);

        }
    }
}
