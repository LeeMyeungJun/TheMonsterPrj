using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BackEnd;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    public GameObject escMenu; // esc UI 패널
    public TMP_Text[] txtNickName; // nickname texts
    public TMP_Text txtTimer; // time text

    public void EscPressed()
    {
        if (GameManager.Instance.isEscPressed)
            CallMenu();
        else
            CloseMenu();
    }

    private void CallMenu()
    {
        GameManager.Instance.isEscPressed = true;
        escMenu.SetActive(true);
        Time.timeScale = 0f; // 시간의 흐름 설정. 0배속. 즉 시간을 멈춤.
    }

    private void CloseMenu()
    {
        GameManager.Instance.isEscPressed = false;
        escMenu.SetActive(false);
        Time.timeScale = 1f; // 1배속 (정상 속도)
    }

    public void SetNickNameTxts()
    {
        foreach (TMP_Text txt in txtNickName)
            txt.text = Backend.UserNickName;
    }
}
