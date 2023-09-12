using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gua_Collider : MonoBehaviour
{
    //��ʼ�ƶ����ߵ�ʱ��
    [SerializeReference] private float act_time;

    const float DISTANCE = 20f;

    //�Ƿ�����if
    bool not_in_if = true;
   

    void Start()
    {
        //���ø��������ƶ����Բ����󲿷�
        transform.Translate(new Vector3(0, DISTANCE, 0),Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        if (_GlobalTimer.t > act_time && not_in_if )
        {
            StartCoroutine("act_now");
            not_in_if = false;
        }
    }

    //����Э�̺�ÿ��2.5s�ͷ�һ������
    IEnumerator act_now()
    {
        int count = 0;
        while (count < 3)
        {
            transform.GetChild(count).GetComponent<Gua_xian_Collider>().canMove = true;
            yield return new WaitForSeconds(2.5f);
            count++;
        }
    }
    
}

