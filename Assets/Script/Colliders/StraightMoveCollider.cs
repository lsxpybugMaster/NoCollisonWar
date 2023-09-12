using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ֱ���ƶ�����ײ��
public class StraightMoveCollider : MonoBehaviour
{
    [SerializeField] Vector3 MoveTarget;
    [SerializeField] float MoveSpeed = 10;
    // Update is called once per frame

    //ʲôʱ�򼤻������Ͳ�����
    public float Activetime;

    private void Start()
    {
            
    }

    void Update()
    {
        //һ�����жϻʱ���Ƿ�Ϊ0  �������˵�����ֶ����Ƽ���ʱ�䣬��ùؿ�һ��������_GlobalTimer
        if (Activetime == 0 || Activetime < _GlobalTimer.t)
        {
            transform.Translate(MoveTarget * MoveSpeed * Time.deltaTime);
        }
    }
}
