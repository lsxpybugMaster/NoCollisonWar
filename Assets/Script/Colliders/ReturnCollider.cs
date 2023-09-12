using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//从左向右，碰到最左侧回弹
public class ReturnCollider : ColliderBase
{
    [SerializeField] float speed;
    [SerializeField] float leftPointX;
    [SerializeField] float rightPointX = 15;

    int direction; // +1向右-1向左
    bool hasReturn;

    void Start()
    {
        hasReturn = false;
        direction = -1;
    }


    void Update()
    {
        if (_GlobalTimer.t >= activeTime)
        {
            CheckPosition();
            Move();
        }
    }

    void CheckPosition()
    {
        if (!hasReturn && transform.position.x <= leftPointX)
        {
           direction *= -1;
           hasReturn = true;
        }

        if(transform.position.x >= rightPointX)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        transform.Translate(direction * speed * Vector3.right * Time.deltaTime);
    }
}
