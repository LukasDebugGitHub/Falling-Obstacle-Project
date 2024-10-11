using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameText;

    private void Update()
    {
        usernameText.text = "User: " + MainManager.Instance.username;
    }
}
