using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExMainScene : MonoBehaviour
{
    public void GoToShootGame()                  //버튼이 호출 할 함수를 제작
    {
        SceneManager.LoadScene("GameScene_Gun");        //GameScene_Gun 이동
    }

    public void GoToJumpGame()                  //버튼이 호출 할 함수를 제작
    {
        SceneManager.LoadScene("GameScene_Jump");        //GameScene_Jump 이동
    }

    public void GoExit()                  //버튼이 호출 할 함수를 제작
    {
        Application.Quit();                         //게임 종료
    }
}
