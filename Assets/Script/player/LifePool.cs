using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���Ѫ����ʾ
public class LifePool : MonoBehaviour
{
    public LifeBall[] lifes;

    //�������Ѫ����ʼ��Ѫ��
    void Start()
    {       
        for (int i = 0; i < PlayerController.instance.HP; i++)
        {
            lifes[i].gameObject.SetActive(true);
        }   
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void decreaseHPBall()
    {
        lifes[PlayerController.instance.HP].DisableMe();
    }
}
