using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//作为额外组件由PlayerMoveController调用
public class PlayerMoveLimit : MonoBehaviour
{
    public float x;
    public float y;
    float xtemp;
    float ytemp;
    Vector3 vtemp;

    //提供一个方法用于判断玩家是否超界。
    public Vector3 Limit(Vector2 pos)
    {
        xtemp = Mathf.Clamp(transform.position.x, -x, x);
        ytemp = Mathf.Clamp(transform.position.y, -y, y);
        vtemp.x = xtemp;
        vtemp.y = ytemp;
        vtemp.z = 0;
        return vtemp;
    }
}
