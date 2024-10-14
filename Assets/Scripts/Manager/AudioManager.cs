using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Sources----------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSouce;

    [Header("----------Audio Clips----------")]
    public AudioClip titleMusic;
    public AudioClip buttonClick;

    private void Start()
    {
        musicSource.clip = titleMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSouce.PlayOneShot(clip);
    }
}
