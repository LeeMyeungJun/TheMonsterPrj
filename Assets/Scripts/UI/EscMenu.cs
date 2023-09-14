using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public void ClickResume()
    {
        GameManager.Instance.isEscMenuOn = !GameManager.Instance.isEscMenuOn;
        UIManager.Instance.EscPressed();
        Debug.Log("게임 재개");
    }

    public void ClickRestart()
    {
        //
        // 재시작 코드
        //
        Debug.Log("재시작");
    }

    public void ClickExit()
    {
        Debug.Log("게임 종료");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
