using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    private void Update()
    {
        usernameText.text = "User: " + MainManager.Instance.username;
        highscoreText.text = "Highscore: " + MainManager.Instance.score;
    }
}
