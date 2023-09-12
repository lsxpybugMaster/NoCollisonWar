using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  TODO： 代码结构有问题需要修改
    FIXME : 代码结构有问题需要修改
 */

//改变玩家颜色的脚本,继承自父类
public class PcolorController : ColorFather
{
    public SpriteRenderer[] playerSprites;
    //用于交互，检测碰撞颜色
    public static int colorCode;

    // Start is called before the first frame update
    void Start()
    {
        changeTime = 0;
        colorCode = 0;
        //开始的默认颜色
        change_color(colorCode);
    }

    // Update is called once per frame
    void Update()
    {
        changeTime += Time.deltaTime;

        if (changeTime >= 2f)
        {
            if (colormode == mode.rgb)
                rgb();
            else
                rinbow();
        } 
    }

    void rgb()
    {
        //调换颜色
        switch(colorCode)
        {              
            case (int)color.red:
                change_color((int)color.green); colorCode = (int)color.green;  break;
            case (int)color.green:
                change_color((int)color.blue);  colorCode = (int)color.blue;  break;
            case (int)color.blue:
                change_color((int)color.red); colorCode = (int)color.red; break;
        }
        //更改颜色指示变量，重置时间  
        changeTime = 0;
    }

    void rinbow()
    {
        //更改颜色指示变量，重置时间 [7 : 彩虹颜色]
        colorCode = (colorCode + 1) % 7;
        changeTime = 0;

        //调换颜色
        change_color(colorCode);  
    }

    void change_color(int idx)
    {
        for (int i = 0; i < playerSprites.Length; i++)
        {
            playerSprites[i].color = colorPlate[idx];
        }
    }

}
