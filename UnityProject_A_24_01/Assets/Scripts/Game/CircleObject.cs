using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;                 //마우스 Drag 판단
    public bool isUsed;                 //사용 완료 체크 
    Rigidbody2D rigidbody2D;            //2D 강체 선언

    public int index;                   //과일 번호 설정 

    public float EndTime = 0.0f;                //종료 선 시간 체크 변수(float)
    public SpriteRenderer spriteRenderer;           //종료시 스프라이트 색을 변환 시키기 위해서 접근 선언

    public GameManager gameManager;                     //게임 매니저 참조용

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();      //오브젝트의 강체에 접근
        isUsed = false;                                 //시작할때 사용이 안되었다고 입력
        rigidbody2D.simulated = false;                  //물리 행동이 처음에는 동작하지 않게 설정

        spriteRenderer = GetComponent<SpriteRenderer>();    //오브젝트에 붙어있는 컴포넌트에 접근
    }

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();                    //게임 매니저를 얻어온다. 
    }

    void Update()
    {
        if (isUsed)                         //사용이 완료된 오브젝트는 업데이트 문을 그냥 돌려 보낸다. (마우스 Input 적용을 막기 위해)
            return;

        if(isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);     //화면 스크린에서 유니티 Scene 공간의 좌표를 가져온다.

            float leftBorder = -5.0f + transform.localScale.x / 2f;     //반지름 만큼 이동 제한
            float rightBorder = 5.0f - transform.localScale.x / 2f;

            if(mousePos.x < leftBorder) mousePos.x = leftBorder;        //마우스 위치가 이동 제한 한곳 이상, 이하로 가면 값을 조절해서 가둔다. 
            if(mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;                                             //오브젝트 Y 축 값 고정 
            mousePos.z = 0;                                             //오브젝트 Z 축 값 고정 
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);      //이 오브젝트를 마우스 위치로 리니어하게 0.2 값만큼씩 이동시켜 따라간다.

        }

        if (Input.GetMouseButtonDown(0)) Drag();            //마우스 버튼이 눌렸을때 Drag 함수 실행
        if (Input.GetMouseButtonUp(0)) Drop();              //마우스 버튼이 올라갈때 Drop 함수 살행 
    }

    void Drag()                             //드래그 할 때 상태 값 함수 
    {
        isDrag = true;                      //드래그 중이다. (true)
        rigidbody2D.simulated = false;      //물리 시뮬레이션 않함 (false)
    }
    void Drop()                             //드랍 할 때 상태 값 함 수
    {
        isDrag = false;                     //드래그 중이다. (false)           
        isUsed = true;                      //사용 완료 되었다. (true)     
        rigidbody2D.simulated = true;       //물리 시율레이션 사용함 (true)

        gameManager.GenObject();
    }

    public void Used()
    {
        isDrag = false;                     //드래그 중이다. (false)           
        isUsed = true;                      //사용 완료 되었다. (true)     
        rigidbody2D.simulated = true;       //물리 시율레이션 사용함 (true)
    }

    public void OnTriggerStay2D(Collider2D collision)           //Trigger에 있을때
    {
        if(collision.tag == "EndLine")                          //충돌중인 물체의 Tag 가 EndLine 일 경우
        {
            EndTime += Time.deltaTime;                                      //프레임 시간만큼 누적 시켜서 초를 카운드 한다. 

            if(EndTime > 1)                                                 //1초 이상 일 경우
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f);         //빨강색 처리 
                
            }
            if(EndTime > 3)                                                 //3초 이상 일 경우
            {
                //Debug.Log("게임 종료");                                     //우선 게임 종료 처리 
                gameManager.EndGame();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)                       //Trigger에서 나올때 
    {
        if (collision.tag == "EndLine")                          //충돌중인 물체의 Tag 가 EndLine 일 경우
        {
            EndTime = 0.0f;
            spriteRenderer.color = Color.white;                 //기본 색상으로 변경 
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)                   //해당 오브젝트가 충돌 했을 때 OnCollisionEnter2D
    {
        if (index >= 7)
            return;
        
        if(collision.gameObject.tag == "Fruit")                             //충돌이 같은 과일일 경우
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();      //출동한 물체에서 같은 Class를 받아온다. 
            
            if(temp.index == index)                                         //충돌 index와 내 index 가 같다. 
            {

                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID()) //2개 합쳐서 1개를 만들기 위해서 ID 검사 후 큰것만 
                {
                    //GameManager에서 합친 오브젝트를 생성 

                    gameManager.MergeObject(index, gameObject.transform.position);

                    Destroy(temp.gameObject);                                   //충돌한 물체 제거
                    Destroy(gameObject);                                        //자신도 제거 
                }

            }
        }
    }
}
