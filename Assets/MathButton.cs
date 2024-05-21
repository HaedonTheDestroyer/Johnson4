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
     GameObject opp;
     GameObject cube;
    ColorChanger changer;
    public TMP_InputField inputField;

    public AudioSource audioSource;

    private void Start()
    {
        changer = FindAnyObjectByType<ColorChanger>();

        meshRenderer = GetComponent<MeshRenderer>();
        opp= changer.opp;
        cube = changer.cube;
        if (answer.Contains("/"))
        {
            double numerator, denominator;
            double.TryParse(answer.Substring(0, answer.IndexOf("/")), out numerator);
            double.TryParse(answer.Substring(answer.IndexOf("/") + 1), out denominator);
            answer = "" + (numerator / denominator);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
    }

    public void QuestionAnswered()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }

        string ans = inputField.text.ToString().ToLower();

        if(ans.Length == 0)
        {
            return;
        }

        answer = answer.ToLower();

        ans = ans.Replace(" ", "");
        answer = answer.Replace(" ", "");

        if (ans.Contains("/"))
        {
            double numerator, denominator;
            double.TryParse(ans.Substring(0, ans.IndexOf("/")), out numerator);
            double.TryParse(ans.Substring(ans.IndexOf("/") + 1), out denominator);
            ans = "" + (numerator / denominator);
        }

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
        if (Random.Range(-1 , 2) != 1)
        {
            for (int i = 0; i < 25; i++) { Instantiate(opp, new Vector3(Random.Range(-40, 45), 1.5f, Random.Range(-40, 45)), new Quaternion()); }
        }
        else
        {
            Instantiate(cube, new Vector3(Random.Range(-40, 45), 1.5f, Random.Range(-40, 45)), new Quaternion());
            Instantiate(cube, new Vector3(Random.Range(-40, 45), 1.5f, Random.Range(-40, 45)), new Quaternion());
        }

       
        
    }

    private void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
