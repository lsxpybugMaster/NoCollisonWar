using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ĳЩ����Խ����������ǽ�壬��Ҫͨ���˽ű��˳���Ĭ�������˳���
public class MoveAway : MonoBehaviour
{
    public float goAwayXaxis; //��x����С��ĳʱ�����˳�ǽ��
    public float speed;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= goAwayXaxis)
        {
            transform.Translate(0,-speed * Time.deltaTime,0);
        }
    }
}
