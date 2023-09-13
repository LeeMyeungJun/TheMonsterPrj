using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

// µÚ³¡ SDK namespace Ãß°¡
using BackEnd;

public class ViewRanking : MonoBehaviour
{
    public TMP_Text myClearTime;
    
    public TMP_Text[] topNames;
    public TMP_Text[] topClearTimes;

    public int gap = 2;
    public RectTransform content;  // [ myRank-gap , myRank+gap ]

    private void Start()
    {
        ViewMyClearTime();
        UpdateRanking();
        ViewMyGapRanking();
    }

    void ViewMyClearTime()
    {
        string c = PlayerPrefs.GetString("clearTime");
        myClearTime.text = "Clear Time : " + c;
    }

    void UpdateRanking()
    {
        BackendRank.Instance.RankGet(out var bro); // ·©Å· BackendReturnObject ¹Þ¾Æ¿È
        for(int idx = 0; idx < 3; idx++)
        {
            //StringBuilder info = new StringBuilder();
            //info.Append(bro.FlattenRows()[idx]["nickname"].ToString().PadRight(20));
            topNames[idx].text = bro.FlattenRows()[idx]["nickname"].ToString();
            topClearTimes[idx].text = string.Format("{0:00}:{1:00}", (int)bro.FlattenRows()[idx]["score"] / 60, (int)bro.FlattenRows()[idx]["score"] % 60);
            //info.Append(bro.FlattenRows()[idx]["score"].ToString());
            //info.Append(string.Format("{0:00}:{1:00}", (int)bro.FlattenRows()[idx]["score"] / 60, (int)bro.FlattenRows()[idx]["score"] % 60));
            //Debug.Log(info);
            //topRanks[idx].text += info.ToString();
        }
    }
    
    void ViewMyGapRanking()
    {
        BackendGameData.Instance.GameDataGet();
        BackendRank.Instance.GetMyGapRank(gap, out var bro);
        Debug.Log("·©Å· ¼ö : " + bro.GetFlattenJSON()["totalCount"].ToString());

        int idx = 0;
        foreach (LitJson.JsonData jsonData in bro.FlattenRows())
        {
            StringBuilder info = new StringBuilder();
            //if (idx == 2)
            if ( Backend.UserNickName== jsonData["nickname"].ToString())
                info.Append("<color=#ff0000>");

            info.Append(jsonData["rank"].ToString().PadRight(20));
            info.Append(jsonData["nickname"].ToString().PadRight(20));
            info.Append(string.Format("{0:00}:{1:00}", (int)jsonData["score"]/60, (int)jsonData["score"]%60));
            //if (idx == 2)
            if (Backend.UserNickName == jsonData["nickname"].ToString())
                info.Append("<color=#ff0000>");
            content.GetChild(idx).GetComponent<TMP_Text>().text = info.ToString();
            idx++;
        }
    }
}
