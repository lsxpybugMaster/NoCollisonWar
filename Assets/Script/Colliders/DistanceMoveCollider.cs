using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��brokeCollider����
public class DistanceMoveCollider : MonoBehaviour
{
    bool act;
    float currentMoveDistance;

    public float speed;
    public Vector3 MoveTarget;
    public float maxMoveDistance;  //�ƶ�����ʱֹͣ

    // Start is called before the first frame update
    void Start()
    {
        act = false;
        currentMoveDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (act)
            Move();
    }

    public void Act()
    {
        act = true;
    }

    public void Move()
    {
        float dis = (MoveTarget * speed * Time.deltaTime).magnitude;
        currentMoveDistance += dis;
        if(currentMoveDistance <= maxMoveDistance)
            transform.Translate(MoveTarget * speed * Time.deltaTime);
    }

    
}
