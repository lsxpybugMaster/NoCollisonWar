using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//模拟激光的脚本，实现从一条细线到粗激光然后消失的功能
public class LaserCollider : MonoBehaviour
{
    //激光宽度
    float laserWidth;
    //扩展速度
    public float spreadSpeed;
    //有伤害的宽度
    public float dangerWidth;

    //延迟销毁的时间
    float destroyDelayTime;

    BoxCollider2D myCollider;
    //用于判断是否执行事件
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.enabled = false;
        laserWidth = 1;
        destroyDelayTime = 0.15f;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
            Laser();
    }

    void Laser()
    {
        // 扩展激光宽度，到达一定宽度时开启碰撞体

        float width = transform.localScale.y + spreadSpeed * Time.deltaTime;
        //宽度限制
        if (width > laserWidth)
        {
            width = laserWidth;

            Destroy(transform.parent.gameObject,destroyDelayTime);
        }
        //到达一定宽度时开启碰撞体
        else if (width > dangerWidth)
            myCollider.enabled = true;
        transform.localScale = new Vector3(transform.localScale.x, width, transform.localScale.z);
    }

    /// <summary>
    /// Listener : 专用于相应父对象事件
    /// </summary>
    //接收信号事件执行此函数
    public void Activeshoot()
    {
        active = true;
    }
}
