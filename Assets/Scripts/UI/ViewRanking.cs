using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

// �ڳ� SDK namespace �߰�
using BackEnd;

public class ViewRanking : MonoBehaviour
{
    
    public TMP_Text[] topRanks;

    public int gap = 2;
    public RectTransform content;  // [ myRank-gap , myRank+gap ]

    private void OnEnable()
    {
        UpdateRanking();
        ViewMyGapRanking();
    }

    //Backend.URank.User.GetMyRank("rankUuid", 3);
    void UpdateRanking()
    {
        //BackendGameData.Instance.GameDataGet();
        BackendRank.Instance.RankGet(out var bro); // ��ŷ BackendReturnObject �޾ƿ�
        for(int idx = 0; idx < 3; idx++)
        {
            /*foreach (LitJson.JsonData jsonData in bro.FlattenRows())
            {
                StringBuilder info = new StringBuilder();
                info.Append(jsonData["nickname"].ToString().PadRight(20));
                info.Append(jsonData["score"].ToString());
                Debug.Log(info);
                topRanks[idx].text += info.ToString();
            }*/

            StringBuilder info = new StringBuilder();
            info.Append(bro.FlattenRows()[idx]["nickname"].ToString().PadRight(20));
            info.Append(bro.FlattenRows()[idx]["score"].ToString());
            Debug.Log(info);
            topRanks[idx].text += info.ToString();
            
        }
        
    }
    
    void ViewMyGapRanking()
    {
        BackendGameData.Instance.GameDataGet();
        BackendRank.Instance.GetMyGapRank(gap, out var bro);
        Debug.Log("��ŷ �� : " + bro.GetFlattenJSON()["totalCount"].ToString());

        int idx = 0;
        foreach (LitJson.JsonData jsonData in bro.FlattenRows())
        {
            StringBuilder info = new StringBuilder();
            if (idx == 2)
                info.Append("<color=#ff0000>");

            /*info.AppendLine("���� : " + jsonData["rank"].ToString());
            info.AppendLine("�г��� : " + jsonData["nickname"].ToString());
            info.AppendLine("���� : " + jsonData["clearTime"].ToString());
            info.AppendLine("gamerInDate : " + jsonData["gamerInDate"].ToString());
            info.AppendLine("���Ĺ�ȣ : " + jsonData["index"].ToString());*/
            info.Append(jsonData["rank"].ToString().PadRight(20));
            info.Append(jsonData["nickname"].ToString().PadRight(17));
            info.Append(jsonData["score"].ToString());
            //info.Append(" / gamerInDate : " + jsonData["gamerInDate"].ToString()); // ���������� owner_inDate
            //info.Append(" / ���Ĺ�ȣ : " + jsonData["index"].ToString());

            //Debug.Log(info);
            //gapRanks[idx].text = $"{jsonData["rank"].ToString()}     {jsonData["nickname"].ToString()}       {jsonData["score"].ToString()}";
            if (idx == 2)
                info.Append("<color=#ff0000>");
            content.GetChild(idx).GetComponent<TMP_Text>().text = info.ToString();
            idx++;
        }
    }
}
