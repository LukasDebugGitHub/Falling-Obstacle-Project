using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserMenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField userInputField;

    public void SaveUser()
    {
        MainManager.Instance.username = userInputField.text;

        MainManager.Instance.LoadUsername();
        MainManager.Instance.SaveUsername();
    }
}
