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

    // �����͸� ������ϱ� ���� �Լ��Դϴ�.(Debug.Log(UserData);)
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
            result.AppendLine($"| {itemKey} : {inventory[itemKey]}��");
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

    // �������� ���� 
    public void GameDataInsert(int _clearTime)
    {
        if (userData == null)
            userData = new UserData();

        Debug.Log("�����͸� �ʱ�ȭ�մϴ�.2");

        //userData.name = "���� ���2";
        userData.nickName = Backend.UserNickName;
        userData.clearTime = _clearTime;


        Debug.Log("�ڳ� ������Ʈ ��Ͽ� �ش� �����͵��� �߰��մϴ�.");
        Param param = new Param();
        param.Add("NICK_NAME", userData.nickName);
        param.Add("CLEAR_TIME", userData.clearTime);


        Debug.Log("�������� ������ ������ ��û�մϴ�.");
        var bro = Backend.GameData.Insert("USER_PR_DATA", param);

        if(bro.IsSuccess())
        {
            Debug.Log("�������� ������ ���Կ� �����߽��ϴ�. : " + bro);

            //������ ���������� �������Դϴ�.
            gameDataRowInDate = bro.GetInDate();
        }
        else
        {
            Debug.LogError("�������� ������ ���Կ� �����߽��ϴ�. : " + bro);
        }
    }
        
    //�������� �ҷ�����
    public void GameDataGet()
    {
        Debug.Log("���� ���� ��ȸ �Լ��� ȣ���մϴ�.");

        var bro = Backend.GameData.GetMyData("USER_PR_DATA", new Where());
        if (bro.IsSuccess())
        {
            Debug.Log("GetMyData ( USER_PR_DATA, ~ ) �� �����߽��ϴ�. : " + bro);


            LitJson.JsonData gameDataJson = bro.FlattenRows(); // Json���� ���ϵ� �����͸� �޾ƿɴϴ�.

            // �޾ƿ� �������� ������ 0�̶�� �����Ͱ� �������� �ʴ� ���Դϴ�.
            if (gameDataJson.Count <= 0)
            {
                Debug.LogWarning("�����Ͱ� �������� �ʽ��ϴ�.");
            }
            else
            {
                gameDataRowInDate = gameDataJson[0]["inDate"].ToString(); //�ҷ��� ���������� �������Դϴ�.

                userData = new UserData();
                userData.nickName = gameDataJson[0]["NICK_NAME"].ToString();
                userData.clearTime = (int)gameDataJson[0]["CLEAR_TIME"];

                Debug.Log("userData : " + userData.ToString());
            }
        }
        else
        {
            Debug.LogError("���� ���� ��ȸ�� �����߽��ϴ�. : " + bro);
        }
    }

    // �������� ����
    /*public void LevelUp()
    {
        
    }*/

    // �������� ����
    public void GameDataUpdate(int _clearTime)
    {
        if (userData == null)
        {
            Debug.LogError("�������� �ٿ�ްų� ���� ������ �����Ͱ� �������� �ʽ��ϴ�. Insert Ȥ�� Get�� ���� �����͸� �������ּ���.");
            return;
        }

        Param param = new Param();
        param.Add("NICK_NAME", userData.nickName);
        param.Add("CLEAR_TIME", _clearTime);

        BackendReturnObject bro = null;

        if(string.IsNullOrEmpty(gameDataRowInDate))
        {
            Debug.Log("�� ���� �ֽ� �������� ������ ������ ��û�մϴ�.");
            bro = Backend.GameData.Update("USER_PR_DATA", new Where(), param);
        }
        else
        {
            Debug.Log($"{gameDataRowInDate}�� �������� ������ ������ ��û�մϴ�.");
            bro = Backend.GameData.UpdateV2("USER_PR_DATA", gameDataRowInDate, Backend.UserInDate, param);
        }

        if (bro.IsSuccess())
        {
            Debug.Log("�������� ������ ������ �����߽��ϴ�. : " + bro);
        }
        else
        {
            Debug.LogError("�������� ������ ������ �����߽��ϴ�. : " + bro);
        }

    }
}
