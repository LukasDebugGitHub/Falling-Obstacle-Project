using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [Header("Player Data")]
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    [Header("Settings Data")]
    [SerializeField] private VolumeSettings volumeSettings;


    private void Start()
    {
        volumeSettings.VolumeData();
    }

    private void Update()
    {
        usernameText.text = "User: " + MainManager.Instance.username;
        highscoreText.text = "Highscore: " + MainManager.Instance.score;
    }

    public void ButtonClickSound()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClick);
    }
}
