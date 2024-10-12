using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    public AudioSource musicClip;

    [SerializeField] Slider slider;


    private void Start()
    {
        musicClip.volume = MainManager.Instance.musicVolume;
        slider.value = MainManager.Instance.musicVolume;
    }

    public void SaveAudioSettings()
    {
        MainManager.Instance.musicVolume = musicClip.volume;

        MainManager.Instance.SaveUsername();
    }

    public void LoadAudioSettings()
    {
        musicClip.volume = MainManager.Instance.musicVolume;
        slider.value = musicClip.volume;
    }
}
