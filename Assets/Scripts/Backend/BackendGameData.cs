using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

using BackEnd;

public class UserData
{
    #region Example Field
    /*public int level = 1;
    public float atk = 3.5f;
    public string info = string.Empty;
    public string name = string.Empty;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public List<string> equipment = new List<string>();*/
    #endregion

    public string nickName = string.Empty;
    public int clearTime = 0;

    // 데이터를 디버깅하기 위한 함수입니다.(Debug.Log(UserData);)
    public override string ToString()
    {
        #region Example Code
        /*StringBuilder result = new StringBuilder();
        result.AppendLine($"level : {level}");
        result.AppendLine($"atk : {atk}");
        result.AppendLine($"info : {info}");
        result.AppendLine($"name : {name}");

        result.AppendLine($"inventory");
        foreach (var itemKey in inventory.Keys)
        {
            result.AppendLine($"| {itemKey} : {inventory[itemKey]}개");
        }

        result.AppendLine($"equipment");
        foreach (var equip in equipment)
        {
            result.AppendLine($"| {equip}");
        }

        return result.ToString();*/
        #endregion

        StringBuilder result = new StringBuilder();
        result.AppendLine($"nickname : {nickName}");
        result.AppendLine($"recordTime : {clearTime}");

        return result.ToString();
    }
}

public class BackendGameData : MonoBehaviour
{
    private static BackendGameData _instance = null;
    public static BackendGameData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendGameData();
            }   
            return _instance;
        }
    }

    public static UserData userData;

    private string gameDataRowInDate = string.Empty;

    // 게임정보 삽입 
    public void GameDataInsert(int _clearTime)
    {
        if (userData == null)
            userData = new UserData();

        Debug.Log("데이터를 초기화합니다.2");

        //userData.name = "신입 용사2";
        userData.nickName = Backend.UserNickName;
        userData.clearTime = _clearTime;


        Debug.Log("뒤끝 업데이트 목록에 해당 데이터들을 추가합니다.");
        Param param = new Param();
        param.Add("NICK_NAME", userData.nickName);
        param.Add("CLEAR_TIME", userData.clearTime);


        Debug.Log("게임정보 데이터 삽입을 요청합니다.");
        var bro = Backend.GameData.Insert("USER_PR_DATA", param);

        if(bro.IsSuccess())
        {
            Debug.Log("게임정보 데이터 삽입에 성공했습니다. : " + bro);

            //삽입한 게임정보의 고유값입니다.
            gameDataRowInDate = bro.GetInDate();
        }
        else
        {
            Debug.LogError("게임정보 데이터 삽입에 실패했습니다. : " + bro);
        }
    }
        
    //게임정보 불러오기
    public void GameDataGet()
    {
        Debug.Log("게임 정보 조회 함수를 호출합니다.");

        var bro = Backend.GameData.GetMyData("USER_PR_DATA", new Where());
        if (bro.IsSuccess())
        {
            Debug.Log("GetMyData ( USER_PR_DATA, ~ ) 에 성공했습니다. : " + bro);


            LitJson.JsonData gameDataJson = bro.FlattenRows(); // Json으로 리턴된 데이터를 받아옵니다.

            // 받아온 데이터의 갯수가 0이라면 데이터가 존재하지 않는 것입니다.
            if (gameDataJson.Count <= 0)
            {
                Debug.LogWarning("데이터가 존재하지 않습니다.");
            }
            else
            {
                gameDataRowInDate = gameDataJson[0]["inDate"].ToString(); //불러온 게임정보의 고유값입니다.

                userData = new UserData();
                userData.nickName = gameDataJson[0]["NICK_NAME"].ToString();
                userData.clearTime = (int)gameDataJson[0]["CLEAR_TIME"];

                Debug.Log("userData : " + userData.ToString());
            }
        }
        else
        {
            Debug.LogError("게임 정보 조회에 실패했습니다. : " + bro);
        }
    }

    // 게임정보 수정
    /*public void LevelUp()
    {
        
    }*/

    // 게임정보 수정
    public void GameDataUpdate(int _clearTime)
    {
        if (userData == null)
        {
            Debug.LogError("서버에서 다운받거나 새로 삽입한 데이터가 존재하지 않습니다. Insert 혹은 Get을 통해 데이터를 생성해주세요.");
            return;
        }

        Param param = new Param();
        param.Add("NICK_NAME", userData.nickName);
        param.Add("CLEAR_TIME", _clearTime);

        BackendReturnObject bro = null;

        if(string.IsNullOrEmpty(gameDataRowInDate))
        {
            Debug.Log("내 제일 최신 게임정보 데이터 수정을 요청합니다.");
            bro = Backend.GameData.Update("USER_PR_DATA", new Where(), param);
        }
        else
        {
            Debug.Log($"{gameDataRowInDate}의 게임정보 데이터 수정을 요청합니다.");
            bro = Backend.GameData.UpdateV2("USER_PR_DATA", gameDataRowInDate, Backend.UserInDate, param);
        }

        if (bro.IsSuccess())
        {
            Debug.Log("게임정보 데이터 수정에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("게임정보 데이터 수정에 실패했습니다. : " + bro);
        }

    }
}
