using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExSoundPlay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))        //1번 키보드를 눌렀을 때
        {
            SoundManager.instance.PlaySound("BackGround");              
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))        //2번 키보드를 눌렀을 때
        {
            SoundManager.instance.PlaySound("Cannon");
        }
    }
}
