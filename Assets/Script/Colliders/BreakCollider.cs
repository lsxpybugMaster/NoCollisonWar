using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreakCollider : ColliderBase
{
    [SerializeField] float speed;    
    [SerializeField] Transform functionPoint; //����˵㿪ʼ���� 
    [SerializeField] Vector3 MoveTarget;

    //�����¼�
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
