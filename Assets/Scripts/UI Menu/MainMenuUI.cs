using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string mainGameName;

    public void StartMainGame()
    {
        SceneManager.LoadScene(mainGameName);
    }

    public void QuitGame()
    {
        Application.Quit();

        EditorApplication.ExitPlaymode();
    }
}
