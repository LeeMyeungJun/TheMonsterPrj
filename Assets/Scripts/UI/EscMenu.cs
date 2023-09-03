using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    private GameObject escMenu; // 일시 정지 UI 패널

    private void Start()
    {
        escMenu = this.gameObject;
    }

    public void ClickResume()
    {
        Debug.Log("게임 재개");
    }

    public void ClickRestart()
    {
        Debug.Log("재시작");
    }

    public void ClickExit()
    {
        Debug.Log("게임 종료");
        Application.Quit();  // 게임 종료 (에디터 상 실행이기 때문에 종료 눌러도 변화 X)
    }
}
