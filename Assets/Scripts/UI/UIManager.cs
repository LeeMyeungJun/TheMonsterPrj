using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using BackEnd;
using System;

public class UIManager : MonoSingle<UIManager>
{
    public TMP_Text txtBossCnt;
    public TMP_Text txtSubCnt;
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

    private void Start()
    {
        SetNickNameTxts();
    }

    public void BossMobCnt()
    {
        txtBossCnt.text = ""+GameManager.Instance.bossMobCnt + " / " + 1;
    }

    public void SubMobCnt()
    {
        txtSubCnt.text = "" + GameManager.Instance.subMobCnt + " / " + GameManager.Instance.subMobMax;
    }

    public void SetNickNameTxts()
    {
        foreach (TMP_Text txt in txtNickName)
            txt.text = Backend.UserNickName;
    }


    #region Timer
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
    #endregion

    #region EscMenu
    public void EscPressed()
    {
        if (GameManager.Instance.isEscMenuOn)
            CallMenu();
        else
            CloseMenu();
    }

    private void CallMenu()
    {
        escMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void CloseMenu()
    {
        escMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    #endregion

    

    
}
