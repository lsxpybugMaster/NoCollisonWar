using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScaleCollider : MonoBehaviour
{   
    public float activeTime;
    public Vector2 xSize;  //x分量min && y分量max 
    public Vector2 ySize;
    public float addSpeedX;
    public float addSpeedY;

    public int addX;
    public int addY;

    [Tooltip("最大的Y速度")]
    public float SpeedY_maxSpeed;  //为0则不考虑
    public float SpeedY_increaseSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        if(_GlobalTimer.t > activeTime)
        {
            ChangeScale();    
        }
    }

    void ChangeSpeedY()
    {
        addSpeedY += Time.deltaTime * SpeedY_increaseSpeed;
        if(addSpeedY > SpeedY_maxSpeed)
        {
            addSpeedY = SpeedY_maxSpeed;
        }
    }

    void ChangeScale()
    {
        //大小先加后减 ,注意size.x.y 对应最大值最小值
        float x = transform.localScale.x;
        if (x >= xSize.y)
            addX = -1;
        if (x < xSize.x)
            addX = 1;

        float y = transform.localScale.y;
        if (y >= ySize.y)  
            addY = -1;
        if (y < ySize.x)
            addY = 1;

        //改变Y轴速度
        if(SpeedY_increaseSpeed != 0) 
        {
            ChangeSpeedY();
        }


        float newx = transform.localScale.x + addX * addSpeedX * Time.deltaTime;
        float newy = transform.localScale.y + addY * addSpeedY * Time.deltaTime;
        if(newx == 0)
            newx = transform.localScale.x;
        if (newy == 0)
            newy = transform.localScale.y;
        transform.localScale = new Vector3(newx, newy, transform.localScale.z);
     
    }

    
}
