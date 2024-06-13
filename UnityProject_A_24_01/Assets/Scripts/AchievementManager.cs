using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;              //싱글톤 패턴을 만들어준다. 
    public List<Achievement> achievements;

    private void Awake()
    {
        if(instance == null)                                //인스턴스가 null 값인지 체크
        {
            instance = this;                                //instance 에 접근할때 이 클래스라고 지칭
            DontDestroyOnLoad(gameObject);                  //지금 이 클래스가 있는 오브젝트는 파괴 되지 않음
        }
        else
        {                                                   //이미 인스턴스가 선언이 되어있으면
            Destroy(gameObject);                            //해당 오브젝트는 파괴 
        }
    }

    public void AddProgress(string achievementName, int amount)     //업적 진행 상황을 추가 하는 함수
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName);    //해당 이름이 있는 업적을 리스트에서 찾아서 가져온다.
        if(achievement != null)
        {
            achievement.AddProgress(amount);                    //찾은 업적의 횟수를 카운팅한다. 
        }
    }


}
