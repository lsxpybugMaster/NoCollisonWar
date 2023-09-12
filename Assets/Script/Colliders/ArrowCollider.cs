using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ͷ��ײ�壬�ᳯ��������
public class ArrowCollider : MonoBehaviour
{
    public float speed;

    //�Ƿ���׼���
    bool isAimmingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        isAimmingPlayer = true;
        //���z��
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //ʹ��ͷ�������
        transform.up = PlayerController.static_transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAimmingPlayer)
        {
            //ʹ��ͷ�������
            transform.up = PlayerController.static_transform.position - transform.position;
        }
        //���û����׼���
        else
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }


    //׷�ٷ�����Ϻ�ֹͣ׷�ٽ����ƶ����ɸ�������ô��¼�
    public void event_startMove()
    {
        isAimmingPlayer = false;
    }

}
