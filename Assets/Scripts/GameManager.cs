using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
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
    }

    // ÀÔ·ÂÅ° (UI)
    public bool isEsc;

    private void Start()
    {
        isEsc = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isEsc = !isEsc;
            UIManager.Instance.EscPressed();
            Debug.Log("GetKeyDown(KeyCode.Escape)");
        }
    }
}

