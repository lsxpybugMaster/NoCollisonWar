using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mytools; //���ı���ӡ�����ռ�


//����Player�ڵ���body�����ԣ�������Sprite�仯����ײ
public class BodyController : MonoBehaviour
{
    private PlayerController parent;
    
    private void Awake()
    {
        parent = transform.parent.GetComponent<PlayerController>();

        //��ֹ���븸�������ƫ��
        transform.localPosition = Vector3.zero;
    }
    //������ײ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������������ײ�壨����ͬ��ɫ��
        if(collision.tag == "Color")
        {
            int enemyColor = (int)collision.gameObject.GetComponent<ColorCollider>().mycolor;
            //���ִ�������ɫ��ײ�壬��ɫ��ͬ��ͨ��
            if(PcolorController.colorCode != enemyColor)
                parent.damaged();
        }
        else
            parent.damaged();                     
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Color")
        {
            int enemyColor = (int)collision.gameObject.GetComponent<ColorCollider>().mycolor;
            //���ִ�������ɫ��ײ�壬��ɫ��ͬ��ͨ��
            if (PcolorController.colorCode != enemyColor)
                parent.damaged();
        }
    }


}
