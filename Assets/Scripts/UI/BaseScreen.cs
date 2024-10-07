using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseScreen : MasterScreen
{
    [SerializeField] private Text username;

    protected override void Awake()
    {
        base.Awake();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        
    }

    public void ChangeUser()
    {
        menu.ChangeScreen(this.gameObject, menu.userScreen);
    }

    public void ExitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}
