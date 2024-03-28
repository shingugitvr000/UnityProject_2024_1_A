using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCylinderMove : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 오브젝의 좌표 설정
        // Vector3 (X,Y,Z) 축을 의미한다. new 는 클래스를 쓰기 위해서 선언 
        // X = X + 5 <- X += 5 (축약 표시)
        // Time.deltaTime 프레임 간격 시간 ex) 60fps 일경우 0.1초라는 수치를 반환 해준다. 
        // 컴퓨터 마다 프레임이 달라도 동일한 이동 속도를 보여줘야 하기때문에 사용 
        gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;

        //이 오브젝트가 X 좌표축 -12 미만으로 내렸을 경우 
        if(gameObject.transform.position.x < -12.0f)
        {
            gameObject.transform.position += new Vector3(24.0f, 0.0f, 0.0f);
            //X축에 24더해서 화면 오른쪽으로 이동 시켜준다. 
        }
    }
}
