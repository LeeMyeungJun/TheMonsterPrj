using UnityEngine;
using System.Threading.Tasks;

// 뒤끝 SDK namespace 추가
using BackEnd;
//https://developer.thebackend.io/unity3d/guide/install?_gl=1*17041e5*_gcl_au*MjYwODQ5MjM3LjE2OTMzNzYzODc.*_ga*NzcwNTYzODY5LjE2OTMzNzYzODc.*_ga_6WF7D6HGHG*MTY5MzM4MjUxNi4yLjEuMTY5MzM4NDA5Ni42MC4wLjA.*_ga_4CS1BC2PY4*MTY5MzM4MjUxNS4yLjEuMTY5MzM4NDYzNi42MC4wLjA.&_ga=2.6728306.178246897.1693376388-770563869.1693376387
public class BackendManager : MonoBehaviour
{
    public static string UserID;
    public static string UserPW;

    void Start()
    {
        var bro = Backend.Initialize(true); // 뒤끝 초기화

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생 
        }
        
        Test();
    }

    async void Test()
    {
        await Task.Run(() =>
        {
            // BackendLogin -------------------------------------------------------------------------
            // 뒤끝 로그인 _ BackendLogin.cs
            //ackendLogin.Instance.CustomLogin(UserID, UserPW);

            // 닉네임 변경 _ BackendLogin.cs
            //BackendLogin.Instance.UpdateNickname("최승우");

            // BackendGamedate -------------------------------------------------------------------------
            // 데이터 삽입 함수
            //BackendGameData.Instance.GameDataInsert();

            // 데이터 불러오기 함수
            //BackendGameData.Instance.GameDataGet();

            // 서버에 불러온 데이터가 존재하지 않을 경우, 데이터를 새로 생성하여 삽입
            //if (BackendGameData.userData == null)
            //{
            //    BackendGameData.Instance.GameDataInsert();
            //}

            // 로컬에 저장된 데이터를 변경
            //BackendGameData.Instance.LevelUp();

            // 서버에 저장된 데이터를 덮어쓰기(변경된 부분만)
            //BackendGameData.Instance.GameDataUpdate(); 

            // Rank -------------------------------------------------------------------------
            // 랭킹 등록
            //BackendRank.Instance.RankInsert(100);

            // 랭킹 불러오기
            //BackendRank.Instance.RankGet();  


            //Debug.Log("테스트를 종료합니다.");
        });
    }

    
}