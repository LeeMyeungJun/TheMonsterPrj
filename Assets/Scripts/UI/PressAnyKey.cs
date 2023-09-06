using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using DG.Tweening;

public class PressAnyKey : MonoBehaviour
{
    public CanvasGroup FadeInTarget;

    public Vector2 EndSize;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("PRESS ANY KEY");

            FadeInTarget.DOFade(1.0f, 0.5f);
            FadeInTarget.blocksRaycasts = true;

            this.gameObject.SetActive(false);
        }
    }
}