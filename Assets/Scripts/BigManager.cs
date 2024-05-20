using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BigManager : MonoBehaviour
{

    public static BigManager instance;

    public AudioMixer audioMixer;

    public bool paused;
    public bool answering;

    private void Start(){
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("musicvol")) * 20);
        audioMixer.SetFloat("SoundVolume", Mathf.Log10(PlayerPrefs.GetFloat("soundvol")) * 20);
    }

    private void Awake(){
        
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }
}
