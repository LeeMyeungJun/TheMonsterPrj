using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using System.Text;

public class ViewRanking : MonoBehaviour
{
    private void Awake()
    {
        UpdateRanking();
    }

    //Backend.URank.User.GetMyRank("rankUuid", 3);
    void UpdateRanking()
    {
        BackendGameData.Instance.GameDataGet();
        BackendRank.Instance.RankGet(out var bro); // ��ŷ BackendReturnObject �޾ƿ�
        foreach (LitJson.JsonData jsonData in bro.FlattenRows())
        {
            StringBuilder info = new StringBuilder();

            /*info.AppendLine("���� : " + jsonData["rank"].ToString());
            info.AppendLine("�г��� : " + jsonData["nickname"].ToString());
            info.AppendLine("���� : " + jsonData["clearTime"].ToString());
            info.AppendLine("gamerInDate : " + jsonData["gamerInDate"].ToString());
            info.AppendLine("���Ĺ�ȣ : " + jsonData["index"].ToString());*/
            info.AppendLine("���� : " + jsonData["rank"].ToString());
            info.AppendLine("�г��� : " + jsonData["nickname"].ToString());
            info.AppendLine("���� : " + jsonData["score"].ToString());
            info.AppendLine("gamerInDate : " + jsonData["gamerInDate"].ToString()); // ���������� owner_inDate
            info.AppendLine("���Ĺ�ȣ : " + jsonData["index"].ToString());
            info.AppendLine();
            Debug.Log(info);
        }
    }
}
