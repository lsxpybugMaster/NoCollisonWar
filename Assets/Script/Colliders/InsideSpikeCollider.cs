using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 内部刺碰撞体
 * 到达指定时间后脱离父物体并执行对应功能，目前是直线射出
 */
public class InsideSpikeCollider : MonoBehaviour
{
    [SerializeField] Vector3 MoveTarget;
    [SerializeField] float MoveSpeed = 10;
    // Update is called once per frame

    //什么时候激活（不激活就不动）
    public float Activetime;

    private void Start()
    {

    }

    void Update()
    {
        //一定先判断活动时间是否为0  如果不是说明是手动控制激活时间，则该关卡一定调用了_GlobalTimer
        if (Activetime == 0 || Activetime < _GlobalTimer.t)
        {
            //脱离父对象,确保其不会跟随父对象移动
            transform.parent = null;

            transform.Translate(MoveTarget * MoveSpeed * Time.deltaTime);
        }
    }
}



