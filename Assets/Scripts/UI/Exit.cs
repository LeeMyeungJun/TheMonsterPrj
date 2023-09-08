using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitApplication()
    {
        Application.Quit();  // 게임 종료 (에디터 상 실행이기 때문에 종료 눌러도 변화 X)
    }
}
