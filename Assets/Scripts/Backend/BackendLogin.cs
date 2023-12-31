using UnityEngine;

using BackEnd;

public class BackendLogin : MonoSingleton<BackendLogin>
{ 
    public void CustomSignUp(string id, string pw, out BackendReturnObject bro)
    {
        // Step2. 회원가입 구현 로직
        Debug.Log("회원가입을 요청합니다.");

        bro = Backend.BMember.CustomSignUp(id, pw);

        if(bro.IsSuccess())
        {
            Debug.Log("회원가입에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("회원가입에 실패했습니다. : " + bro);
        }
    }

    public void CustomLogin(string id, string pw, out BackendReturnObject bro)
    {
        // Step3. 로그인 구현 로직
        Debug.Log("로그인을 요청합니다.");

        bro = Backend.BMember.CustomLogin(id, pw);
        
        if (bro.IsSuccess())
        {
            Debug.Log("로그인에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("로그인에 실패했습니다. : " + bro);
        }
    }

    public void UpdateNickname(string nickname)
    {
        // Step4. 닉네임 변경 구현 로직
        Debug.Log("닉네임 변경을 요청합니다.");
        
        var bro = Backend.BMember.UpdateNickname(nickname);
        //Backend.BMember.GetUserInfo().
        if (bro.IsSuccess())
        {
            Debug.Log("닉네임 변경에 성공했습니다 : " + bro);
        }
        else
        {
            Debug.LogError("닉네임 변경에 실패했습니다 : " + bro);
        }
        
    }
}
