using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           //UI�� ����
using DG.Tweening;              //Dotween ���

public class TweenUI : MonoBehaviour
{
    public float duration = 1f;             //�ð��� ����
    private Image image;                    //UI Image �� ����

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();          //������Ʈ ��������
        image.DOFade(0f , duration);            //���̵� ȿ��
        image.DOPlay();                         //���̵� �÷���
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
