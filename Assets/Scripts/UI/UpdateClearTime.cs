using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpdateClearTime : MonoBehaviour
{
    public TMP_Text txtTimer;
    public TMP_Text txtClearTime;
    string[] t;
    int clearTime;

    private void OnEnable()
    {
        txtClearTime.text = "Clear : " + txtTimer.text;
        UpdateData();
    }
    // 데이터 삽입 함수
    public void UpdateData()
    {
        UIManager.Instance.TimerStop();

        t = txtTimer.text.Split(":");
        clearTime = Convert.ToInt32(t[0]) * 60 + Convert.ToInt32(t[1]);

        if (BackendGameData.userData == null)
        {
            // Seconds
            BackendGameData.Instance.GameDataInsert(clearTime);
        }
        else
        {
            BackendGameData.Instance.GameDataUpdate(clearTime);
        }
        //BackendRank.Instance.RankGet();

        // 랭킹 업데이트
        BackendRank.Instance.RankInsert(clearTime);
    }
}
