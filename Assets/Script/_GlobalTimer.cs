using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ȫ�ּ�ʱ��
public class _GlobalTimer : MonoBehaviour
{
    //ȫ�ּ�ʱ���µ�ȫ��ʱ��
    public static float t;

    [SerializeField] float timeSet = 0;   //�����ֶ����ó�ʼʱ�����ڲ���

    //public static bool seeTurial = false;  //public static ������ʹ�����ؿ�Ҳ�������ã�
    void Start()
    {
        //��start�г�ʼ�����Է����¿�ʼ����ʱtimeδ������
        t = timeSet;
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;              
    }

 
}
