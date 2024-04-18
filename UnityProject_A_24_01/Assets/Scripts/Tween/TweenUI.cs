using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           //UI에 접근
using DG.Tweening;              //Dotween 사용

public class TweenUI : MonoBehaviour
{
    public float duration = 1f;             //시간값 선언
    private Image image;                    //UI Image 에 접근

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();          //컴포넌트 가저오기
        image.DOFade(0f , duration);            //페이드 효과
        image.DOPlay();                         //페이드 플레이
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
