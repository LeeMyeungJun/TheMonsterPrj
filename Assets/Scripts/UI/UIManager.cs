using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BackEnd;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject escMenu; // esc UI ÆÐ³Î
    public TMP_Text[] txtNickName; // nickname texts
    public TMP_Text txtTimer; // time text
    float time;
    bool isTimerOn;

    private void Update()
    {
        if (isTimerOn)
        {
            TimerOn();
        }

    }

    public void TimerStart()
    {
        print("TimerStart");

        time = 0;
        isTimerOn = true;
    }
    private void TimerOn()
    {
        time += Time.deltaTime;
        
        txtTimer.text = string.Format("{0:00}:{1:00}", ((int)time / 60), ((int)time % 60));
    }
    public void TimerStop()
    {
        print("TimerStop");

        isTimerOn = false;
    }


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
        Time.timeScale = 0f;
    }

    private void CloseMenu()
    {
        GameManager.Instance.isEscPressed = false;
        escMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetNickNameTxts()
    {
        foreach (TMP_Text txt in txtNickName)
            txt.text = Backend.UserNickName;
    }

    
}
