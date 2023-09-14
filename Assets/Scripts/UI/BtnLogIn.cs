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
            // �α��� �� �� ��ȯ
            Debug.Log("�� ��ȯ");
            LoadingSceneController.LoadScene("IngameUIScene");
        }
        else
        {
            Debug.Log("���Է� �ٶ�");
            inputField_ID.text = "";
            inputField_PW.text = "";
        }
    }

}
