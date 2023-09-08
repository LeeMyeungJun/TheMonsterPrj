using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    // ют╥бе╟ (UI)
    public bool isEscPressed;

    private void Start()
    {
        isEscPressed = false;
    }

    private void Update()
    {
        KeyCtrl();
    }

    private void KeyCtrl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isEscPressed = !isEscPressed;
            UIManager.Instance.EscPressed();
            Debug.Log("GetKeyDown(KeyCode.Escape)");
        }
    }
}

