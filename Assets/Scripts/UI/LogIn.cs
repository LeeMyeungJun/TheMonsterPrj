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
            // �α��� �� �� ��ȯ
            //
            UIManager.Instance.SetNickNameTxts();
        }
        else
        {
            
            Debug.Log("�α��� ����.  ���Է� �ٶ�");
            inputField_ID.text = "";
            inputField_PW.text = "";
        }
    }
}
