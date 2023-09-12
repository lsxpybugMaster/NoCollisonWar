using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//用于将某些功能性障碍物引入，到达位置后可以等待一段时间后发送信号
public class Mover : MonoBehaviour
{
    //可以直线移动到多个点
    [SerializeReference] Transform[] pos;
    [SerializeReference] float speed;
    [SerializeReference] float rotateSpeed;
    [SerializeReference] bool NotRotate;

    //什么时候激活（不激活就不动）
    public float Activetime;
    //等待时间
    public float waitTime;

    //激活事件
    public UnityEvent actEvent;

    bool reach = false;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 120;
        if (NotRotate)
            rotateSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reach)
        {
            moveToPosition();
            selfRotate();
        }

        // 检查子对象数量
        if (transform.childCount == 0)
        {
            Destroy(transform.parent.gameObject); //当子对象（即功能性障碍物）销毁时，同时销毁一整套对象
            //包含：总空父对象，mover，tar
        }
    }

    void moveToPosition()
    {
        //一定先判断活动时间是否为0  如果不是说明是手动控制激活时间，则该关卡一定调用了_GlobalTimer
        if (Activetime == 0 || Activetime < _GlobalTimer.t)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos[index].position, speed * Time.deltaTime);
            //当非常接近对应位置时，切换目标

            if ((pos[index].position - transform.position).magnitude < 0.2f)
            {
                //如果未到达最后的位置，则自增index，引导至下一位置
                if (index < pos.Length - 1)
                    index++; //index自增                
                //否则说明已经到达最后的位置，准备执行事件
                else
                {
                    reach = true;
                    StartCoroutine(activeEventwithDelay());
                }  
            }
        }
    }

    //投弹时旋转
    void selfRotate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private IEnumerator activeEventwithDelay()
    {
        yield return new WaitForSeconds(waitTime); // 等待时间
        //触发事件，等待对应实体响应
        actEvent.Invoke();
    }
}
