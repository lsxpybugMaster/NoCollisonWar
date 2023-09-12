using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorSets;


//对于含有不同性质玩家碰撞体组合的情况，每个单体使用此脚本
public class PartBodyController : MonoBehaviour
{
    [SerializeField] private PlayerController pc; //需要在编辑器获取玩家控制器
    //用于交互，检测碰撞颜色
    [SerializeField] private color mycolor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 依情况忽略特殊碰撞体（如相同颜色）
        if (collision.tag == "Color")
        {
            int enemyColor = (int)collision.gameObject.GetComponent<ColorCollider>().mycolor;
            //发现触碰了颜色碰撞体，颜色相同则通过
            if ((int)mycolor != enemyColor)
                pc.damaged();
        }
        else
            pc.damaged();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Color")
        {
            int enemyColor = (int)collision.gameObject.GetComponent<ColorCollider>().mycolor;
            //发现触碰了颜色碰撞体，颜色相同则通过
            if ((int)mycolor != enemyColor)
                pc.damaged();
        }
    }
}
