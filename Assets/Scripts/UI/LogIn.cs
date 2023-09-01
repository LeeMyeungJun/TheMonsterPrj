using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LogIn : MonoBehaviour
{
    public TMP_InputField inputField_ID;
    public TMP_InputField inputField_PW;

    void GetIDPW()
    {
        BackendManager.UserID = inputField_ID.text;
        BackendManager.UserPW = inputField_PW.text;
    }

    public void Btn_LogIn()
    {
        GetIDPW();

        BackendLogin.Instance.CustomLogin(BackendManager.UserID, BackendManager.UserPW);
    }
}
