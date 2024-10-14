using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;

    public void ButtonClickSound()
    {
        audioManager.PlaySFX(audioManager.buttonClick);
    }
}
