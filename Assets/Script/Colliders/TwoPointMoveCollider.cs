using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ԭλ�ߵ�0���ߵ�1
public class TwoPointMoveCollider : MonoBehaviour
{
    [SerializeReference] Transform[] pos;
    [SerializeReference] float speed;
    
    int index = 0;
  
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position , pos[index].position , speed * Time.deltaTime);
        //���ǳ��ӽ���Ӧλ��ʱ���л�Ŀ��

        if ((pos[index].position - transform.position).magnitude < 0.2f)
            index ^= 1; //index������0,1֮�������л�
    }
}

