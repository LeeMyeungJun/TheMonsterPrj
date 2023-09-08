using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BackEnd;

public class LogIn : MonoBehaviour
{
    public TMP_InputField inputField_ID;
    public TMP_InputField inputField_PW;
    private BackendReturnObject bro;

    void GetIDPW()
    {
        BackendManager.UserID = inputField_ID.text;
        BackendManager.UserPW = inputField_PW.text;
    }

    public void Btn_LogIn()
    {
        GetIDPW();

        BackendLogin.Instance.CustomLogin(BackendManager.UserID, BackendManager.UserPW, out bro);

        if (bro.IsSuccess())
        {
            //
            // 로그인 시 씬 전환
            //
            UIManager.Instance.SetNickNameTxts();
        }
        else
        {
            
            Debug.Log("로그인 실패.  재입력 바람");
            inputField_ID.text = "";
            inputField_PW.text = "";
        }
    }
}
