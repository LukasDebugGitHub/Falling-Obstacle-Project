using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("----------Audio Sources----------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSouce;

    [Header("----------Audio Clips----------")]
    public AudioClip titleMusic;
    public AudioClip buttonClick;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


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
