using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]       //클래스 직열화
public class Achievement
{
    public string name;                     //업적 이름
    public string description;              //업적 설명
    public bool isUnlocked;                 //완료 닫힘
    public int currentProgress;             //현재 진행 상태
    public int goal;                        //완료 목표 수


    //생성자 함수 (New 통해서 생성될때 관련 파라미터 값을 넣어주면 생성시 초기화 시켜준다)
    public Achievement(string name, string description, int goal)     
    {
        this.name = name;                   //업적 이름 인수로 받아온다.
        this.description = description;     //업적 설명값을 인수로 받아온다.
        this.isUnlocked = false;            //완료 X
        this.currentProgress = 0;           //초기값 0
        this.goal = goal;                   //완료값을 인수로 받아온다.

    }

    public void AddProgress(int amount)     //횟수를 받아서 완료값 체크
    {
        if(!isUnlocked)                     //업적이 완료가 되지 않은 상태일 때
        {
            currentProgress += amount;      //인수 횟수만큼 카운트 업

            if(currentProgress >= goal)     //골 횟수를 초과시
            {
                isUnlocked = true;          //완료 처리
                OnAchievementUnlocked();

            }
        }
    }
    protected virtual void OnAchievementUnlocked()  //보호수준과 가상함수(virtual) 처리를 해서 상속 시 함수를 갱신할 수 있게 선언
    {
        Debug.Log($"업적 달성: {name}");
    }
}
