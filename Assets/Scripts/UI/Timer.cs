using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private void OnEnable()
    {
        UIManager.Instance.TimerStart();
    }
    private void OnDisable()
    {
        UIManager.Instance.TimerStop();
    }
}
