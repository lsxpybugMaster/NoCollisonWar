using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//子弹碰撞体，接收信号后发射
public class BulletCollider : MonoBehaviour
{
    bool active = false;
    [SerializeField] float MoveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
    }

    //接收信号执行此函数
    public void Activeshoot()
    {
        active = true;
    }
}
