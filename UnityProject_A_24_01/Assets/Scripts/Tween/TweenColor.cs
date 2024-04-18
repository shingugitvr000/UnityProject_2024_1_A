using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;                  //Dotween �� ����ϱ� ���� 

public class TweenColor : MonoBehaviour
{
    private Renderer renderer;                      //�������� �����Ѵ�.

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();        //������Ʈ�� �����´�.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))             //�����̽��� ������ ��
        {
            Color color = new Color(Random.value, Random.value, Random.value);      //���� ���� �����´�. 

            renderer.material.DOColor(color , 1f)               //���������� 1���Ŀ� ����ȴ�.
                .SetEase(Ease.InOutQuad);

            renderer.material.DOPlay();                         //���� Ʈ���� �Ѳ����� ���� ��Ų��.
        }
    }
}
