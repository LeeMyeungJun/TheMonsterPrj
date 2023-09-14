using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private void OnEnable()
    {
        try
        {
            UIManager.Instance.TimerStart();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }
    private void OnDisable()
    {
        try
        {
            UIManager.Instance.TimerStop();
        }
        catch (Exception e) 
        {
            Debug.Log(e.Message);
        }
    }
}
