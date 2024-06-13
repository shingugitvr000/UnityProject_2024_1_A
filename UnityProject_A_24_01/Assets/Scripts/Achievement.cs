using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]       //Ŭ���� ����ȭ
public class Achievement
{
    public string name;                     //���� �̸�
    public string description;              //���� ����
    public bool isUnlocked;                 //�Ϸ� ����
    public int currentProgress;             //���� ���� ����
    public int goal;                        //�Ϸ� ��ǥ ��


    //������ �Լ� (New ���ؼ� �����ɶ� ���� �Ķ���� ���� �־��ָ� ������ �ʱ�ȭ �����ش�)
    public Achievement(string name, string description, int goal)     
    {
        this.name = name;                   //���� �̸� �μ��� �޾ƿ´�.
        this.description = description;     //���� ������ �μ��� �޾ƿ´�.
        this.isUnlocked = false;            //�Ϸ� X
        this.currentProgress = 0;           //�ʱⰪ 0
        this.goal = goal;                   //�Ϸᰪ�� �μ��� �޾ƿ´�.

    }

    public void AddProgress(int amount)     //Ƚ���� �޾Ƽ� �Ϸᰪ üũ
    {
        if(!isUnlocked)                     //������ �Ϸᰡ ���� ���� ������ ��
        {
            currentProgress += amount;      //�μ� Ƚ����ŭ ī��Ʈ ��

            if(currentProgress >= goal)     //�� Ƚ���� �ʰ���
            {
                isUnlocked = true;          //�Ϸ� ó��
                OnAchievementUnlocked();

            }
        }
    }
    protected virtual void OnAchievementUnlocked()  //��ȣ���ذ� �����Լ�(virtual) ó���� �ؼ� ��� �� �Լ��� ������ �� �ְ� ����
    {
        Debug.Log($"���� �޼�: {name}");
    }
}
