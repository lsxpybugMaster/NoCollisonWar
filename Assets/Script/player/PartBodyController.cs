using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorSets;


//���ں��в�ͬ���������ײ����ϵ������ÿ������ʹ�ô˽ű�
public class PartBodyController : MonoBehaviour
{
    [SerializeField] private PlayerController pc; //��Ҫ�ڱ༭����ȡ��ҿ�����
    //���ڽ����������ײ��ɫ
    [SerializeField] private color mycolor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������������ײ�壨����ͬ��ɫ��
        if (collision.tag == "Color")
        {
            int enemyColor = (int)collision.gameObject.GetComponent<ColorCollider>().mycolor;
            //���ִ�������ɫ��ײ�壬��ɫ��ͬ��ͨ��
            if ((int)mycolor != enemyColor)
                pc.damaged();
        }
        else
            pc.damaged();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Color")
        {
            int enemyColor = (int)collision.gameObject.GetComponent<ColorCollider>().mycolor;
            //���ִ�������ɫ��ײ�壬��ɫ��ͬ��ͨ��
            if ((int)mycolor != enemyColor)
                pc.damaged();
        }
    }
}
