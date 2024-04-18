using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PunchScaleTween : MonoBehaviour
{
    public bool isPunch = false;            //플레그 값 선언   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))            //스페이스 키를 누르면 
        {
            if(!isPunch)            //펀치 중이 중이 아닐 때(펀치 중일때는 키보드를 눌러도 효과가 들어가지 않음)
            {
                isPunch = true;         //펀치 중으로 상태값을 만든다.
                //펀치 효과를 주고 효과가 끝나면 EndPunch 함수 호출
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f, 10, 1).OnComplete(EndPunch);    
                
            }
        }
    }
    void EndPunch()
    {
        isPunch = false;
    }
}
