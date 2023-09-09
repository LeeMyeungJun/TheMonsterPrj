using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BtnSignUp : MonoBehaviour
{
    public CanvasGroup FadeOutTarget;
    public CanvasGroup FadeInTarget;

    public void btn_SignUp()
    {
        Debug.Log("btn_SignUp");

        FadeOutTarget.DOFade(0.0f, 0.2f);
        FadeOutTarget.blocksRaycasts = false;

        FadeInTarget.DOFade(1.0f, 0.2f);
        FadeInTarget.blocksRaycasts = true;
    }
}
