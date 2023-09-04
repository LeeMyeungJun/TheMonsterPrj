using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    [SerializeField] private GameObject escMenu; // esc UI �г�

    public void EscPressed()
    {

        if (GameManager.Instance.isEsc)
            CallMenu();
        else
            CloseMenu();
    }

    private void CallMenu()
    {
        GameManager.Instance.isEsc = true;
        escMenu.SetActive(true);
        Time.timeScale = 0f; // �ð��� �帧 ����. 0���. �� �ð��� ����.
    }

    private void CloseMenu()
    {
        GameManager.Instance.isEsc = false;
        escMenu.SetActive(false);
        Time.timeScale = 1f; // 1��� (���� �ӵ�)
    }

    private void Update()
    {

    }
}
