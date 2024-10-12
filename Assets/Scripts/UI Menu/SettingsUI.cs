using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    private AudioSettingsUI audioSettings;


    private void Start()
    {
        audioSettings = GetComponentInChildren<AudioSettingsUI>();


        audioSettings.musicClip.Play();
    }

    public void SaveSettings()
    {
        audioSettings.SaveAudioSettings();
    }

    public void LoadSettings()
    {
        audioSettings.LoadAudioSettings();

    }
}
