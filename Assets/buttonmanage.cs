using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonmanage : MonoBehaviour
{
    public void b1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void levelselect()
    {
        SceneManager.LoadScene("level select");
    }

    public void settings()
    {
        SceneManager.LoadScene("settings");
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
