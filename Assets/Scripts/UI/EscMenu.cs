using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public void ClickResume()
    {
        GameManager.Instance.isEscMenuOn = !GameManager.Instance.isEscMenuOn;
        UIManager.Instance.EscPressed();
        Debug.Log("GetKeyDown(KeyCode.Escape)");
        Debug.Log("���� �簳");
    }

    public void ClickRestart()
    {
        //
        // ����� �ڵ�
        //
        Debug.Log("�����");
    }

    public void ClickExit()
    {
        Debug.Log("���� ����");
        Application.Quit();  // ���� ���� (������ �� �����̱� ������ ���� ������ ��ȭ X)
    }
}
