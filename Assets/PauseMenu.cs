using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseUI;
    public GameObject GameUI;
    public GameObject QuestionUI;
    public GameObject SettingsUI;

    public AudioSource[] audioSources;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (BigManager.instance.answering)
            {
                return;
            }

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

    public void Settings()
    {
        PauseUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void Back()
    {
        SettingsUI.SetActive(false);
        PauseUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {
        Resume();
        SceneManager.LoadScene("Level Select");
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        GameUI.SetActive(true);
        SettingsUI.SetActive(false);

        BigManager.instance.paused = false;

        Time.timeScale = 1f;

        foreach (AudioSource audioSource in audioSources)
        {

            if(audioSource == null)
            {
                continue;
            }

            if (audioSource.gameObject.activeInHierarchy)
            {
                audioSource.UnPause();
            }
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        BigManager.instance.paused = true;

        Time.timeScale = 0f;

        foreach (AudioSource audioSource in audioSources)
        {

            if (audioSource == null)
            {
                continue;
            }

            if (audioSource.gameObject.activeInHierarchy)
            {
                audioSource.Pause();
            }
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        GameUI.SetActive(false);
        PauseUI.SetActive(true);
    }
}