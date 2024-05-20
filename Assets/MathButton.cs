using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public int questionNumber;

    public TMP_InputField inputField;

    public AudioSource audioSource;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        incorrectText.SetActive(false);

        if (QuestionManager.questions[questionNumber - 1])
        {
            return;
        }

        gameUI.SetActive(false);
        question.SetActive(true);

        audioSource.Pause();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;

        BigManager.instance.answering = true;
        BigManager.instance.paused = true;
    }

    public void QuestionAnswered()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }

        string ans = inputField.text.ToString().ToLower();
        answer = answer.ToLower();

        ans = ans.Replace(" ", "");
        answer = answer.Replace(" ", "");

        inputField.text = "";

        Time.timeScale = 1.0f;

        BigManager.instance.paused = false;
        BigManager.instance.answering = false;

        audioSource.UnPause();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        gameUI.SetActive(true);
        question.SetActive(false);

        double ansnum1;
        double ansnum2;

        bool correct = ans == answer;

        if (double.TryParse(ans, out ansnum1) && double.TryParse(answer, out ansnum2))
        {
            if(ansnum1 == ansnum2)
            {
                correct = true;
            }
        }

        if (correct)
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
            for(int i = 0; i < 4; i++)
            {
                QuestionManager.questions[i] = false;
            }
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
