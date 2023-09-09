using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BackEnd;
using DG.Tweening;

public class BtnSignUpRequest : MonoBehaviour
{
    public TMP_InputField inputField_NickName;
    public TMP_InputField inputField_ID;
    public TMP_InputField inputField_PW;
    public CanvasGroup FadeOutTarget;
    public CanvasGroup FadeInTarget;
    private BackendReturnObject bro;

    void GetIDPW()
    {
        //BackendManager.UserID = inputField_ID.text;
        //BackendManager.UserPW = inputField_PW.text;
    }

    public void btn_SignUpRequest()
    {
        //GetIDPW();
        if(inputField_NickName.text == "")
        {
            Debug.Log("회원가입 실패.  닉네임을 입력해주세요");
        }
        else
        {
            //BackendLogin.Instance.CustomSignUp(BackendManager.UserID, BackendManager.UserPW, out bro);
            BackendLogin.Instance.CustomSignUp(inputField_ID.text, inputField_PW.text, out bro);

            if (bro.IsSuccess())
            {
                BackendLogin.Instance.UpdateNickname(inputField_NickName.text);

                FadeOutTarget.DOFade(0.0f, 0.2f);
                FadeOutTarget.blocksRaycasts = false;

                FadeInTarget.DOFade(1.0f, 0.2f);
                FadeInTarget.blocksRaycasts = true;
            }
            else
            {
                Debug.Log("회원가입 실패.  재입력 바람");
                inputField_NickName.text = "";
                inputField_ID.text = "";
                inputField_PW.text = "";
            }
        }
       
    }
}
