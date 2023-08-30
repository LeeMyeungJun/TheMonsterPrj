using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 뒤끝 SDK namespace 추가
using BackEnd;
//https://developer.thebackend.io/unity3d/guide/install?_gl=1*17041e5*_gcl_au*MjYwODQ5MjM3LjE2OTMzNzYzODc.*_ga*NzcwNTYzODY5LjE2OTMzNzYzODc.*_ga_6WF7D6HGHG*MTY5MzM4MjUxNi4yLjEuMTY5MzM4NDA5Ni42MC4wLjA.*_ga_4CS1BC2PY4*MTY5MzM4MjUxNS4yLjEuMTY5MzM4NDYzNi42MC4wLjA.&_ga=2.6728306.178246897.1693376388-770563869.1693376387
public class BackendManager : MonoBehaviour
{
    void Start()
    {
        var bro = Backend.Initialize(true); // 뒤끝 초기화

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생 
        }
    }
}