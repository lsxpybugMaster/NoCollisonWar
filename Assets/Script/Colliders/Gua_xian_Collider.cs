using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��һ������/������ʹ�õ��ƶ����������Լ���λ���ƶ�һ�ξ����ֹͣ
public class Gua_xian_Collider : MonoBehaviour
{
    [SerializeReference] private float speed;
    //�����������
    [HideInInspector] public bool canMove = false;

    //���������������Ӧ���ƶ��ľ���
    const float DISTANCE = 20f;
    
    //�������
    float distance = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //����������޸���canMove������Ի��Ӧ�ƶ�ָ�������ֹͣ
        if(canMove && distance < DISTANCE)
        {
            float deltaDistance = speed * Time.deltaTime;
            distance += deltaDistance;
            transform.Translate(0, -deltaDistance,0,Space.Self);
        }
    }

   
}
