using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//改变对象的大小和透明度，模拟爆炸
public class BomberCollider : MonoBehaviour
{
    public float scaleSpeed = 0.5f;     // 放大速度
    public float alphaSpeed = 0.5f;     // 透明度变化速度
    public float targetScale = 2f;      // 目标尺寸(倍数)
    public float targetAlpha = 0f;      // 目标透明度

    private Vector3 initialScale;        // 初始尺寸
    private Color initialColor;          // 初始颜色
    private Renderer myrenderer;           // 渲染器
    Vector3 e;

    //开关
    bool active = false;

    void Start()
    {
        initialScale = transform.localScale;
        myrenderer = GetComponent<Renderer>();
        if (myrenderer != null)
        {
            initialColor = myrenderer.material.color;
        }

        e = new Vector3(1,1,1);
    }

    void Update()
    {
        //收到mover投弹器的信号后激活
        if (active)
        {
            // 改变尺寸(匀速改变)
            if (transform.localScale.x < targetScale)
            {
                transform.localScale += scaleSpeed * Time.deltaTime * e;
            }
            else //尺寸达到最大，消散
            {
                Destroy(gameObject);
            }

            // 改变透明度
            if (myrenderer != null)
            {
                float nowAlpha = myrenderer.material.color.a;

                float newAlpha = Mathf.Lerp(nowAlpha, targetAlpha, alphaSpeed * Time.deltaTime);
                myrenderer.material.color = new Color(initialColor.r, initialColor.g, initialColor.b, newAlpha);
            }
        }
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
