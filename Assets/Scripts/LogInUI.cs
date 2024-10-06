using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInUI : MonoBehaviour
{

    public void ContinueToMenu()
    {
        MainManager.Instance.SaveUsername();
        SceneManager.LoadScene("Menu");
    }
}
