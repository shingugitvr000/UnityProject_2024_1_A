using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExResultScene : MonoBehaviour
{
    public Text TextUI;                                     //UI 컴포넌트를 받아와서

    public void Start()
    {
        TextUI.text = PlayerPrefs.GetInt("Point").ToString();           //int로 저장된 Point를 가져와서 toString()함수로 문자열로 변환해준다.
    }

    public void GoToGame()                  //버튼이 호출 할 함수를 제작
    {
        SceneManager.LoadScene("MainScene");        //MainScene 이동(수정)
    }
}
