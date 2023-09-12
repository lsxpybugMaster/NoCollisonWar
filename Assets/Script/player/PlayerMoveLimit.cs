using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��Ϊ���������PlayerMoveController����
public class PlayerMoveLimit : MonoBehaviour
{
    public float x;
    public float y;
    float xtemp;
    float ytemp;
    Vector3 vtemp;

    //�ṩһ�����������ж�����Ƿ񳬽硣
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
