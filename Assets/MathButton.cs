using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathButton : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    public GameObject question;
    public GameObject gameUI;
    public GameObject incorrectText;
    public GameObject correctText;
    public string answer;
    private bool answered;
    public int questionNumber;

    public TMP_InputField inputField;

    public AudioSource audioSource;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (answered)
        {
            return;
        }

        gameUI.SetActive(false);
        question.SetActive(true);

        audioSource.Pause();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;

        BigManager.instance.paused = true;
    }

    public void QuestionAnswered()
    {
        string ans = inputField.text.ToString().ToUpper();

        inputField.text = "";

        Time.timeScale = 1.0f;

        BigManager.instance.paused = false;

        audioSource.Play();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        gameUI.SetActive(true);
        question.SetActive(false);

        answered = true;
        bool correct = ans == answer;

        if(correct)
        {
            meshRenderer.material.color = new Color32(0, 255, 0, 255);
        }
        else
        {
            incorrectText.SetActive(true);
            Invoke(nameof(sunfish), 1f);
        }

        QuestionManager.questions[questionNumber - 1] = correct;

        if (QuestionManager.AllCorrect())
        {
            correctText.SetActive(true);
            Invoke(nameof(LoadNext), 1f);
        }

    }

    private void sunfish()
    {
        incorrectText.SetActive(false);
    }

    private void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
