using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScreen : MonoBehaviour
{
    protected MenuUIHandler menu;

    protected virtual void Awake()
    {
        menu = GetComponentInParent<MenuUIHandler>();

        menu.InitialScreen(gameObject, menu.baseScreen);
    }
}
