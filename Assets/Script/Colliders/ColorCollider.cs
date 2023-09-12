using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//本脚本用于带有颜色的障碍物，需要挂载到已经有功能的障碍物上，本身不能执行
public class ColorCollider : ColorFather
{  
    //用于交互，检测碰撞颜色
    public color mycolor;
    
    //是否是变色障碍物  
    public bool changeColor;
    //如果是变色障碍物则去变色
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        //颜色障碍物默认是不变色的，只储存一个颜色信息
        //七色就不必改颜色

        if (changeColor)
        {   
            sprite = GetComponent<SpriteRenderer>();
            
        }
    }

    void Update()
    {
        changeTime += Time.deltaTime;

        if (changeColor == true && changeTime >= 2f)
        {
            //if (colormode == mode.rgb)
            rgb();
            //TODO ： 后续可能还会加上七色变化
            //else: pass
        }
    }

    void rgb()
    {
        //0 -> 红  1 -> 绿  2 -> 蓝 
        //调换颜色
        switch (mycolor)
        {
            case color.red:
                change_color(1) ;  mycolor = color.green; break;
            case color.green:
                change_color(2) ;  mycolor = color.blue ; break;
            case color.blue:
                change_color(0) ;  mycolor = color.red   ; break;
        }
        //更改颜色指示变量，重置时间  
        changeTime = 0;
    }

    void change_color(int idx)
    {   
         sprite.color = colorPlate[idx];   
    }

}
