using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家血条显示
public class LifePool : MonoBehaviour
{
    public LifeBall[] lifes;

    //根据玩家血量初始化血豆
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
