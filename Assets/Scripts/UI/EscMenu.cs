using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    private GameObject escMenu; // �Ͻ� ���� UI �г�

    private void Start()
    {
        escMenu = this.gameObject;
    }

    public void ClickResume()
    {
        Debug.Log("���� �簳");
    }

    public void ClickRestart()
    {
        Debug.Log("�����");
    }

    public void ClickExit()
    {
        Debug.Log("���� ����");
        Application.Quit();  // ���� ���� (������ �� �����̱� ������ ���� ������ ��ȭ X)
    }
}
