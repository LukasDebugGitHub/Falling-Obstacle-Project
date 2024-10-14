using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [Header("Screen Info")]
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject playerInfo;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameSucceed;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    [Header("Player Info")]
    [SerializeField] private Text liveText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timerText;

    [Header("Game Info")]
    [SerializeField] private int liveNumber;
    [SerializeField] private float timerValue;

    private int scoreValue = 0;
    private bool isTimerOn;

    private int highscore;

    public bool isGameOn { get; private set; }

    private void Awake()
    {
        highscore = MainManager.Instance.score;

        #region Active Screen UI
        title.gameObject.SetActive(true);
        playerInfo.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        gameSucceed.gameObject.SetActive(false);
        #endregion
    }

    private void Start()
    {
        isGameOn = false;
    }

    public void StartOfTheGame()
    {
        // Game starts
        isGameOn = true;
        isTimerOn = true;

        playerInfo.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void GameOver()
    {
        // Game lose
        isGameOn = false;

        gameOver.gameObject.SetActive(true);
    }

    public void GameFinished()
    {
        // Game won
        isGameOn = false;

        gameSucceed.gameObject.SetActive(true);

        finalScoreText.text = "Final Score: " + scoreValue;

        SetHighscore();

        MainManager.Instance.SaveUsername();
    }

    private void SetHighscore()
    {   
        if (highscore < scoreValue)     // New Highscore, save the highsore to MainManager
        {
            highscore = scoreValue;
            highscoreText.text = "New Highscore: " + highscore;
            MainManager.Instance.score = highscore;
        }
        else if (highscore >= scoreValue)   // Current Highscore, if the old one was not beaten
        {
            highscoreText.text = "Highscore: " + highscore;
        }
    }

    public void Score(Collider other)
    {
        // Count the different types of fruits
        if (other.gameObject.CompareTag("Apple"))
        {
            scoreValue += 5;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Coconut"))
        {
            scoreValue += 10;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Watermelon"))
        {
            scoreValue += 15;
            Destroy(other.gameObject);
        }

        scoreText.text = "Score: " + scoreValue;
    }

    public void Live(Collision collision)
    {
        // Decrease the Live of the player, when he gets hitten by the spike ball
        if (collision.gameObject.CompareTag("SpikeBall"))
        {
            // Get hitten by the Spike Ball
            Destroy(collision.gameObject);

            liveNumber -= 1;
            liveText.text = "Live: " + liveNumber;
        }

        if (liveNumber == 0)
        {
            GameOver();
        }
    }

    public void Timer()
    {
        // The timer, when the level ends and the new level starts.
        if (isTimerOn)
        {
            if (timerValue > 0)
            {
                timerValue -= Time.deltaTime;
                updateTimer(timerValue);
            }
            else
            {
                // Time is up
                timerValue = 0;
                isTimerOn = false;
                GameFinished();
            }
        }
    }

    private void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
}
