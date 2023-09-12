using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollider : MonoBehaviour
{
    [SerializeField] float activeTime;
    [SerializeField] float speed;
    [SerializeField] float colorDecreaseSpeed; //ɫ�ʽ����ٶ�
    [SerializeField] Transform stealthPoint; //����˵㿪ʼ����
    [SerializeField] Transform visablePoint; //����˵�������
    [SerializeField] Vector3 MoveTarget;
    bool isStealth;
    bool hasStealthed;

    [SerializeField]bool DEBUG;
    // bool nearPlayer; //�������ʱ��������һ�ײ���

    Color color;
    SpriteRenderer SR;
    float alpha; //ɫ��͸����

    // Start is called before the first frame update
    void Start()
    {
        isStealth = false;
        hasStealthed = false;
        //nearPlayer = false;

        SR = GetComponent<SpriteRenderer>();     
        color = SR.color;

        alpha = 1.0f;

        colorDecreaseSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_GlobalTimer.t >= activeTime)
        {
            CheckTwoPoints();
            if(!DEBUG)
                CheckStealth();
            Move();
            
        }
    }

    void CheckTwoPoints()
    {
        if(!hasStealthed && Vector2.Distance(transform.position, stealthPoint.position) < 0.1f)
        {
            hasStealthed = true;
            isStealth = true;
        }

        if(hasStealthed && Vector2.Distance(transform.position,visablePoint.position) < 0.1f)
        {
            isStealth = false ;
        }
    }


    //�������״̬�����������״̬������
    void CheckStealth()
    {
        //����״̬���𽥼�С��ɫ͸����
        if(isStealth)
        { 
            alpha -= colorDecreaseSpeed * Time.deltaTime;
            if(alpha < 0.0f) alpha = 0.0f;
            SR.color = new Color(color.r, color.g, color.b, alpha);
        }
        //�����������״̬���һ��Ѿ��������ˣ�������͸����
        else if(hasStealthed)
        {
            alpha += colorDecreaseSpeed * Time.deltaTime;
            if (alpha > 1.0f) alpha = 1.0f;
            SR.color = new Color(color.r, color.g, color.b, alpha);
        }
    }

    void Move()
    {
        transform.Translate(MoveTarget * speed * Time.deltaTime);
    }

    //void CheckPlayer()
    //{
      
    //    if(Vector2.Distance(PlayerController.static_transform.position, transform.position) < 2f)
    //    {
    //        nearPlayer = true;
    //        SR.color = new Color(color.r, color.g, color.b, 1);
    //    }
    //    else
    //    {
    //        nearPlayer = false;
    //    }
    //}
}
