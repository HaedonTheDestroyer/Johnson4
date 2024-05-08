using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseUI;
    public GameObject GameUI;
    public GameObject QuestionUI;

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource audioSource5;
    public AudioSource audioSource6;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (BigManager.instance.paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Resume()
    {

    }

    private void Pause()
    {
        BigManager.instance.paused = true;

        Time.timeScale = 0f;


    }
}