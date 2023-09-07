using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    /*private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }*/
    
    // ÀÔ·ÂÅ° (UI)
    public bool isEscPressed;

    private void Start()
    {
        isEscPressed = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isEscPressed = !isEscPressed;
            UIManager.Instance.EscPressed();
            Debug.Log("GetKeyDown(KeyCode.Escape)");
        }
    }
}

