using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Text username;
    private void Start()
    {
        username.text = "User: " + MainManager.Instance.myUsername.text;
    }
    private void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}
