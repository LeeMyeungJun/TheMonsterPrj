using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BtnSignUp : MonoBehaviour
{
    //public TMP_InputField inputField_ID;
    //public TMP_InputField inputField_PW;
    public CanvasGroup FadeOutTarget;
    public CanvasGroup FadeInTarget;
    /*void GetIDPW()
    {
        BackendManager.UserID = inputField_ID.text;
        BackendManager.UserPW = inputField_PW.text;
    }*/

    public void btn_SignUp()
    {
        Debug.Log("PRESS ANY KEY");

        FadeOutTarget.DOFade(0.0f, 0.2f);
        FadeOutTarget.blocksRaycasts = false;

        FadeInTarget.DOFade(1.0f, 0.2f);
        FadeInTarget.blocksRaycasts = true;
        //this.gameObject.SetActive(false);
        /*GetIDPW();
        BackendLogin.Instance.CustomSignUp(BackendManager.UserID, BackendManager.UserPW, out bro);

        if (bro.IsSuccess())
        {
            Debug.Log("btn_SignUpRequest 회원가입에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("btn_SignUpRequest 회원가입에 실패했습니다. : " + bro);
        }*/
    }
}
