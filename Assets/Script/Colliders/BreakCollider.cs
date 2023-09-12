using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreakCollider : ColliderBase
{
    [SerializeField] float speed;    
    [SerializeField] Transform functionPoint; //到达此点开始分裂 
    [SerializeField] Vector3 MoveTarget;

    //激活事件
    public UnityEvent actEvent;

    void Start()
    {
    }

    
    void Update()
    {
        if (_GlobalTimer.t >= activeTime)
        {
            CheckPoint();
            Move();
        }
    }

    void CheckPoint()
    {
        if(Vector2.Distance(transform.position,functionPoint.position) < 0.1f)
        {
            actEvent.Invoke();
        }
    }

    void Move()
    {
        transform.Translate(MoveTarget * speed * Time.deltaTime);
    }
}
