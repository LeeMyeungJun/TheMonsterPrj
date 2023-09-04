using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateClearTime : MonoBehaviour
{
    public Text txtTimer;
    string[] t;

    private void Awake()
    {
        UpdateData();
    }
    // 데이터 삽입 함수
    public void UpdateData()
    {
        BackendGameData.Instance.GameDataGet();
        t = txtTimer.text.Split(":");
        if (BackendGameData.userData == null)
        {
            // Seconds
            BackendGameData.Instance.GameDataInsert(Convert.ToInt32(t[0]) * 60 + Convert.ToInt32(t[1]));
        }
        else
        {
            BackendGameData.Instance.GameDataUpdate(Convert.ToInt32(t[0]) * 60 + Convert.ToInt32(t[1]));
        }
            
        
       
    }
}
