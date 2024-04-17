using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class slidermanage : MonoBehaviour
{
    public AudioMixer SoundEffectsMixer;
    public AudioMixer MusicMixer;
    public Slider musicslider;
    public Slider soundslider;
    public Slider sensslider;

    void Start()
    {
        if (PlayerPrefs.GetInt("bitch") != 1)
        {
            PlayerPrefs.SetFloat("musicvol", 1);
            PlayerPrefs.SetFloat("soundvol", 1);
            PlayerPrefs.SetFloat("sens", 1);
            PlayerPrefs.SetInt("bitch", 1);
        }
        musicslider.value = PlayerPrefs.GetFloat("musicvol");
        soundslider.value = PlayerPrefs.GetFloat("soundvol");
        sensslider.value = PlayerPrefs.GetFloat("sens");
    }

    public void SetSoundEffectsVolume(float volume)
    {
        PlayerPrefs.SetFloat("soundvol", volume);
        SoundEffectsMixer.SetFloat("SoundEffectsVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("musicvol", volume);
        MusicMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("sens", sensitivity);
        Debug.Log(PlayerPrefs.GetFloat("sens"));
    }

}
