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

    [SerializeField] private GameObject escMenu; // esc UI 패널

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
        Time.timeScale = 0f; // 시간의 흐름 설정. 0배속. 즉 시간을 멈춤.
    }

    private void CloseMenu()
    {
        GameManager.Instance.isEsc = false;
        escMenu.SetActive(false);
        Time.timeScale = 1f; // 1배속 (정상 속도)
    }

    private void Update()
    {

    }
}
