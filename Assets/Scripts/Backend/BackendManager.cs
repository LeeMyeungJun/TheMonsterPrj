using UnityEngine;
using System.Threading.Tasks;

// �ڳ� SDK namespace �߰�
using BackEnd;
//https://developer.thebackend.io/unity3d/guide/install?_gl=1*17041e5*_gcl_au*MjYwODQ5MjM3LjE2OTMzNzYzODc.*_ga*NzcwNTYzODY5LjE2OTMzNzYzODc.*_ga_6WF7D6HGHG*MTY5MzM4MjUxNi4yLjEuMTY5MzM4NDA5Ni42MC4wLjA.*_ga_4CS1BC2PY4*MTY5MzM4MjUxNS4yLjEuMTY5MzM4NDYzNi42MC4wLjA.&_ga=2.6728306.178246897.1693376388-770563869.1693376387
public class BackendManager : MonoBehaviour
{
    public static string UserID;
    public static string UserPW;

    void Start()
    {
        var bro = Backend.Initialize(true); // �ڳ� �ʱ�ȭ

        // �ڳ� �ʱ�ȭ�� ���� ���䰪
        if (bro.IsSuccess())
        {
            Debug.Log("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 204 Success
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogError("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 400�� ���� �߻� 
        }
        
        Test();
    }

    async void Test()
    {
        await Task.Run(() =>
        {
            // BackendLogin -------------------------------------------------------------------------
            // �ڳ� �α��� _ BackendLogin.cs
            //ackendLogin.Instance.CustomLogin(UserID, UserPW);

            // �г��� ���� _ BackendLogin.cs
            //BackendLogin.Instance.UpdateNickname("�ֽ¿�");

            // BackendGamedate -------------------------------------------------------------------------
            // ������ ���� �Լ�
            //BackendGameData.Instance.GameDataInsert();

            // ������ �ҷ����� �Լ�
            //BackendGameData.Instance.GameDataGet();

            // ������ �ҷ��� �����Ͱ� �������� ���� ���, �����͸� ���� �����Ͽ� ����
            //if (BackendGameData.userData == null)
            //{
            //    BackendGameData.Instance.GameDataInsert();
            //}

            // ���ÿ� ����� �����͸� ����
            //BackendGameData.Instance.LevelUp();

            // ������ ����� �����͸� �����(����� �κи�)
            //BackendGameData.Instance.GameDataUpdate(); 

            // Rank -------------------------------------------------------------------------
            // ��ŷ ���
            //BackendRank.Instance.RankInsert(100);

            // ��ŷ �ҷ�����
            //BackendRank.Instance.RankGet();  


            //Debug.Log("�׽�Ʈ�� �����մϴ�.");
        });
    }

    
}