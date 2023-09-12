using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mytools; //富文本打印命名空间


//控制Player节点下body的属性，处理其Sprite变化和碰撞
public class BodyController : MonoBehaviour
{
    private PlayerController parent;
    
    private void Awake()
    {
        parent = transform.parent.GetComponent<PlayerController>();

        //防止其与父对象相对偏移
        transform.localPosition = Vector3.zero;
    }
    //处理碰撞
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 依情况忽略特殊碰撞体（如相同颜色）
        if(collision.tag == "Color")
        {
            int enemyColor = (int)collision.gameObject.GetComponent<ColorCollider>().mycolor;
            //发现触碰了颜色碰撞体，颜色相同则通过
            if(PcolorController.colorCode != enemyColor)
                parent.damaged();
        }
        else
            parent.damaged();                     
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Color")
        {
            int enemyColor = (int)collision.gameObject.GetComponent<ColorCollider>().mycolor;
            //发现触碰了颜色碰撞体，颜色相同则通过
            if (PcolorController.colorCode != enemyColor)
                parent.damaged();
        }
    }


}
