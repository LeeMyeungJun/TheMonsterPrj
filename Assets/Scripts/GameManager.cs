using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingle<GameManager>
{
    // ют╥бе╟ (UI)
    public bool isEscMenuOn;

    private void Start()
    {
        isEscMenuOn = false;
    }

    private void Update()
    {
        KeyCtrl();
    }

    private void KeyCtrl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isEscMenuOn = !isEscMenuOn;
            UIManager.Instance.EscPressed();
            Debug.Log("GetKeyDown(KeyCode.Escape)");
        }
    }
}

