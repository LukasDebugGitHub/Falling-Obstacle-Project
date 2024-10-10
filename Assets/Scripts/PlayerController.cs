using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player info")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float xAxisBorder;


    private GameManager gameManagerScript;

    private Rigidbody rbPlayer;

    private void Start()
    {
        gameManagerScript = FindAnyObjectByType<GameManager>();
        rbPlayer = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (gameManagerScript.isGameOver != true && gameManagerScript.isGameStarted == true)
        {
            MoveController();
            AxisBorder();
        }
    }

    private void MoveController()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = Vector3.right * horizontalInput * moveSpeed;
    }

    private void AxisBorder()
    {
        // Border on the x Axis
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
