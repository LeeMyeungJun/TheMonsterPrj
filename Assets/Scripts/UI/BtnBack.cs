using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BtnBack : MonoBehaviour
{
    public CanvasGroup FadeOutTarget;
    public CanvasGroup FadeInTarget;

    public void Btn_Back()
    {
        FadeOutTarget.blocksRaycasts = false;
        FadeOutTarget.DOFade(0.0f, 0.2f);

        FadeInTarget.blocksRaycasts = true;
        FadeInTarget.DOFade(1.0f, 0.5f);
    }
}
