using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManagerScript;

    private Rigidbody rbPlayer;

    [SerializeField] float speed = 12.0f;

    private void Start()
    {
        gameManagerScript = FindAnyObjectByType<GameManager>();
        rbPlayer = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (gameManagerScript.isGameOver != true && gameManagerScript.isGameStarted == true)
        {
            // Horizontal Input Control
            Vector3 horizontalInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

            rbPlayer.MovePosition(transform.position + horizontalInput * Time.deltaTime * speed);
        }
    }
    void Update()
    {
        float xAxisBorder = 23.0f;

        // Border on the z Axis
        if (transform.position.x > xAxisBorder)
        {
            transform.position = new Vector3(xAxisBorder, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xAxisBorder)
        {
            transform.position = new Vector3(-xAxisBorder, transform.position.y, transform.position.z);
        }  
    }
}
