using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{

    public GameObject baseScreen;
    public GameObject userScreen;


    public void InitialScreen(GameObject _everyGameObject, GameObject _baseScreen)
    {
        _everyGameObject.SetActive(false);
        _baseScreen.SetActive(true);
    }


    public void ChangeScreen(GameObject _currentScreen, GameObject _nextScreen)
    {
        _currentScreen.SetActive(false);
        _nextScreen.SetActive(true);
    }

}
