using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//箭头碰撞体，会朝向玩家射击
public class ArrowCollider : MonoBehaviour
{
    public float speed;

    //是否瞄准玩家
    bool isAimmingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        isAimmingPlayer = true;
        //清空z轴
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //使箭头朝向玩家
        transform.up = PlayerController.static_transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAimmingPlayer)
        {
            //使箭头朝向玩家
            transform.up = PlayerController.static_transform.position - transform.position;
        }
        //如果没有瞄准玩家
        else
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }


    //追踪方向完毕后，停止追踪进行移动，由父对象调用此事件
    public void event_startMove()
    {
        isAimmingPlayer = false;
    }

}
