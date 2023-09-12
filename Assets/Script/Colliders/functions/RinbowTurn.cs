using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 ����������ת�Ľű�
 */


public class RinbowTurn : MonoBehaviour
{
    public float speed;
    //����ٶ�
    public float maxspeed;
    //��������ٶ�ʱ��ʱ��
    public float timeNeed;
    //�����ƽ��ÿ��Ӷ����ٶ�
    float delta;
  
    // Start is called before the first frame update
    void Start()
    {
        delta = (maxspeed - speed) / timeNeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < maxspeed)
        {
            speed += delta * Time.deltaTime;
        }   
        transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
    }
}
