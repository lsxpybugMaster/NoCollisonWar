using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMoveCollider : MonoBehaviour
{
    [SerializeReference] Transform[] pos;
    [SerializeReference] float speed;
    int index = 0;

    //什么时候激活（不激活就不动）
    public float Activetime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //一定先判断活动时间是否为0  如果不是说明是手动控制激活时间，则该关卡一定调用了_GlobalTimer
        if (Activetime == 0 || Activetime < _GlobalTimer.t)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos[index].position, speed * Time.deltaTime);
            //当非常接近对应位置时，切换目标

            if ((pos[index].position - transform.position).magnitude < 0.2f)
                if (index < pos.Length - 1)
                    index++; //index自增  
        }

    }
}
