using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Obstacle types")]
    [SerializeField] private GameObject[] fruits;
    [SerializeField] private GameObject spikeBall;

    [Header("Spawn info")]
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnRepeatRate;

    private GameManager gameManagerScript;
    
    private void Start()
    {
        gameManagerScript = FindAnyObjectByType<GameManager>();

        InvokeRepeating("ObstacleSpawner", spawnTime, spawnRepeatRate);
    }

    private void ObstacleSpawner()
    {
        if (gameManagerScript.isGameOver != true && gameManagerScript.isGameStarted == true)
        {
            float yHeight = 35.0f;
            float xRange = 23.0f;
            float xSpawnRange = Random.Range(-xRange, xRange);

            int randomFruit = Random.Range(0, fruits.Length);
            int randomObstacle = Random.Range(0, fruits.Length + 1);

            Vector3 spawnPosition = new Vector3(xSpawnRange, yHeight, 0);

            if (randomObstacle < fruits.Length)
            {
                Instantiate(fruits[randomFruit], spawnPosition, transform.rotation);
            }
            else
            {
                Instantiate(spikeBall, spawnPosition, transform.rotation);
            }
        }
    }
}
