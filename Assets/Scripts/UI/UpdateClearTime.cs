using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateClearTime : MonoBehaviour
{
    public Text txtTimer;
    string[] t;
    int clearTime;

    private void Awake()
    {
        //UpdateData();
    }
    // ������ ���� �Լ�
    public void UpdateData()
    {
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

        // ��ŷ ������Ʈ
        BackendRank.Instance.RankInsert(clearTime);
    }
}
