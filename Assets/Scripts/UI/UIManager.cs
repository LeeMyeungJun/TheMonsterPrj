using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BackEnd;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject("UIManager");
                    _instance = obj.AddComponent<UIManager>();
                }
            }
            return _instance;
        }
    }

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
    #endregion

    

    
}
