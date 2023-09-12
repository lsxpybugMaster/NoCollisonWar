using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMoveCollider : MonoBehaviour
{
    [SerializeReference] Transform[] pos;
    [SerializeReference] float speed;
    int index = 0;

    //ʲôʱ�򼤻������Ͳ�����
    public float Activetime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //һ�����жϻʱ���Ƿ�Ϊ0  �������˵�����ֶ����Ƽ���ʱ�䣬��ùؿ�һ��������_GlobalTimer
        if (Activetime == 0 || Activetime < _GlobalTimer.t)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos[index].position, speed * Time.deltaTime);
            //���ǳ��ӽ���Ӧλ��ʱ���л�Ŀ��

            if ((pos[index].position - transform.position).magnitude < 0.2f)
                if (index < pos.Length - 1)
                    index++; //index����  
        }

    }
}
