using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//颜色关卡脚本的父类
/*
    派生玩家颜色
    障碍物颜色
 */
namespace ColorSets
{
    public enum color
    {
        red, orange, yellow, green, cyan, blue, purple
    }

}

public class ColorFather : MonoBehaviour
{
    //存储颜色
    public Color[] colorPlate;
    public mode colormode;

    [HideInInspector] public float changeTime;

    public enum color
    {
        red, orange, yellow, green, cyan, blue, purple
    }

    public enum mode
    {
        rgb, rinbow
    }
}

