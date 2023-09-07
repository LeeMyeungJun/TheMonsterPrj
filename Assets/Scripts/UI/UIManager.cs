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

    public GameObject escMenu; // esc UI �г�
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
        Time.timeScale = 0f; // �ð��� �帧 ����. 0���. �� �ð��� ����.
    }

    private void CloseMenu()
    {
        GameManager.Instance.isEscPressed = false;
        escMenu.SetActive(false);
        Time.timeScale = 1f; // 1��� (���� �ӵ�)
    }

    public void SetNickNameTxts()
    {
        foreach (TMP_Text txt in txtNickName)
            txt.text = Backend.UserNickName;
    }
}
