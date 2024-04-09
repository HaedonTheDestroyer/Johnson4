using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelMen : MonoBehaviour
{
    // Start is called before the first frame update
    public Button[] butts;
    public int unlockedLevels;
    public bool gameon;
    public void open(int ind)
    {
        SceneManager.LoadScene(ind);
    }
    public void Start()
    {
       
    }
    public void Awake()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //PlayerPrefs.SetInt("levels", 0);
        unlockedLevels = PlayerPrefs.GetInt("levels");
        if (gameon)
        {
            for (int i = 0; i < butts.Length; i++)
            {
                butts[i].interactable = false;
            }
            for (int i = 0; i < unlockedLevels-4; i++)
            {
                butts[i].interactable = true;
            }
        }

    }
}
