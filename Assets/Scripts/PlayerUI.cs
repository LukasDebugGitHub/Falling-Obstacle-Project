using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private GameManager gameManagerScript;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private Text liveText;
    [SerializeField] private Text timerText;

    private int scoreValue = 0;
    [SerializeField] private int liveNumber = 3;
    [SerializeField] private float timerValue = 180.0f;
    private bool isTimerOn;

    private void Start()
    {
        gameManagerScript = FindAnyObjectByType<GameManager>();
        isTimerOn = true;
    }
    private void Update()
    {
        Timer();
    }
    private void OnTriggerEnter(Collider other)
    {
        Score(other);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Live(collision);
    }

    void Score(Collider other)
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

    void Live(Collision collision)
    {
        // Decrease the Live of the player, when he gets hitten by the spike ball
        if (collision.gameObject.CompareTag("SpikeBall"))
        {
            Debug.Log("Get hitten by the Spike Ball!");
            Destroy(collision.gameObject);

            liveNumber -= 1;
            liveText.text = "Live: " + liveNumber;
        }

        if (liveNumber == 0)
        {
            gameManagerScript.GameOver();
        }
    }

    void Timer()
    {
        // The timer, when the level ends and the new level starts.
        if (isTimerOn && gameManagerScript.isGameOver != true && gameManagerScript.isGameStarted == true)
        {
            if (timerValue > 0)
            {
                timerValue -= Time.deltaTime;
                updateTimer(timerValue);
            }
            else
            {
                Debug.Log("Time is UP!");
                timerValue = 0;
                isTimerOn = false;
                gameManagerScript.GameFinished(scoreValue);
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
}
