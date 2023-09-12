using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ʱ��תһ���ǶȵĹ���
public class RotateSomeAngle : MonoBehaviour
{
    public float startRotateTime;
    public float rotateAngle;
    public float rotateSpeed;

    float rotateAngleNow;
    float add;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(_GlobalTimer.t > startRotateTime)
        {
            RotateMe();
        }
    }

    void RotateMe()
    {
        add = Time.deltaTime * rotateSpeed;

        rotateAngleNow += add;
        if(rotateAngleNow < rotateAngle)
            transform.Rotate(0, 0, add);
    }
}
