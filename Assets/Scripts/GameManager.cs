using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitGameButton;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI gameFinishedText;
    [SerializeField] private Text finalScoreText;

    public bool isGameOver;
    public bool isGameStarted;

    private void Start()
    {
        isGameStarted = false;
        isGameOver = false;
        
        restartButton.gameObject.SetActive(false);
        titleText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        gameFinishedText.gameObject.SetActive(false);

        startButton.onClick.AddListener(StartOfTheGame);
        restartButton.onClick.AddListener(RestartGame);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    void StartOfTheGame()
    {
        Debug.Log("Game starts!");
        isGameStarted = true;
        titleText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameFinished(int scoreValue)
    {
        Debug.Log("Game won!");
        isGameStarted = false;
        gameFinishedText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + scoreValue;
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
