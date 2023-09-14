using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BackEnd;
using System.Threading.Tasks;

public class BtnLogIn : MonoBehaviour
{
    public TMP_InputField inputField_ID;
    public TMP_InputField inputField_PW;
    private BackendReturnObject bro;

    public void Btn_LogIn()
    {
        BackendLogin.Instance.CustomLogin(inputField_ID.text, inputField_PW.text, out bro);

        if (bro.IsSuccess())
        {
            // 로그인 시 씬 전환
            Debug.Log("씬 전환");
            LoadingSceneController.LoadScene("IngameUIScene");
        }
        else
        {
            Debug.Log("재입력 바람");
            inputField_ID.text = "";
            inputField_PW.text = "";
        }
    }

}
