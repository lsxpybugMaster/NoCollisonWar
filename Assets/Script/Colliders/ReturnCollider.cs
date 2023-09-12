using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������ң����������ص�
public class ReturnCollider : ColliderBase
{
    [SerializeField] float speed;
    [SerializeField] float leftPointX;
    [SerializeField] float rightPointX = 15;

    int direction; // +1����-1����
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
