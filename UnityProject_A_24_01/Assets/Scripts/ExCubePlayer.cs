using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExCubePlayer : MonoBehaviour
{   
    public Text TextUI = null;              //�ؽ�Ʈ UI
    public int Count = 0;                   //���콺 Ŭ�� ī����
    public int Power = 100;            //���� �� ��ġ
    public Rigidbody m_Rigidbody;           //������Ʈ�� ��ü 

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space)) //�����̽��� ���� �� 
        {
            Count += 1;                                 //���콺�� Ŭ���Ǿ����� Count�� 1�� �ø���.
            TextUI.text = Count.ToString();                 //UI ����
            Power = Random.Range(100, 200);                 // 100 ~ 200 ������ ���� ���� �ش�
            m_Rigidbody.AddForce(transform.up * Power);     //Y������ ������ ���� �ش�.            
        }

        if(gameObject.transform.position.y >= 2 || gameObject.transform.position.y <= -2)
        {   //������Ʈ�� y���� -2 �����̰ų� 2�̻��ϰ�� ���ǹ�
            TextUI.text = "����";
            Count = 0;                                  //���н� ī���� �ʱ�ȭ
        }
    }
}
