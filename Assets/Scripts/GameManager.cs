using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingle<GameManager>
{
    // ÀÔ·ÂÅ° (UI)
    public bool isEscMenuOn;
    
    public int bossMobCnt;
    public int subMobCnt;
    public int subMobMax;

    private void Start()
    {
        bossMobCnt = 1;
        subMobMax = 10;
        subMobCnt = subMobMax;
        isEscMenuOn = false;
    }

    private void Update()
    {
        KeyCtrl();

        UIManager.Instance.SubMobCnt();
        UIManager.Instance.BossMobCnt();

        if(bossMobCnt == 0)
            StageClear();
        
    }

    private void StageClear()
    {
        LoadingSceneController.LoadScene("ClearScene");
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

