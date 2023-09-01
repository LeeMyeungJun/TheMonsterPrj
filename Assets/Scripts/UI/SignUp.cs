using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SignUp : MonoBehaviour
{
    public TMP_InputField inputField_ID;
    public TMP_InputField inputField_PW;

    void GetIDPW()
    {
        BackendManager.UserID = inputField_ID.text;
        BackendManager.UserPW = inputField_PW.text;
    }

    public void Btn_SignUp()
    {
        GetIDPW();

        BackendLogin.Instance.CustonSignUp(BackendManager.UserID, BackendManager.UserPW);
    }
}
