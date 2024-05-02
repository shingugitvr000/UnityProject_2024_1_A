using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject circleObject;             //물체 프리팹을 가져온다.
    public Transform genTransform;              //생성 위치 설정
    public float timeCheck;                     //생성 시간 설정 변수(float)
    public bool isGen;                          //생성 체크 (bool)

    public void GenObject()                     //생성 관련 변수값 변경 시켜주는 함수 
    {
        isGen = false;                          //생성 완료 되었으니 bool 을 false 변경 
        timeCheck = 1.0f;                       //생성 완료 후 1.0초로 시간 초기화
    }

    // Start is called before the first frame update
    void Start()
    {
        GenObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGen == false)                                      //isGen 플레그가 false 일 경우
        {
            timeCheck -= Time.deltaTime;                        //매 프레임 돌아가면서 시간을 감소 시킨다.
            if(timeCheck <= 0.0f)                                //0초 이하가 되었을 경우
            {
                GameObject Temp = Instantiate(circleObject);     //프리팹 생성후 Temp 오브젝트에 넣는다. 
                Temp.transform.position = genTransform.position;    //고정 위치에 생성 시킨다.
                isGen = true;
            }
        }
    }
}
