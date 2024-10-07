using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserScreen : MasterScreen
{
    [SerializeField] private InputField username;
    [SerializeField] private Button returnToMenu;

    protected override void Awake()
    {
        base.Awake();
    }

    public void ReturnToMenu()
    {
        menu.ChangeScreen(this.gameObject, menu.baseScreen);
    }
}
