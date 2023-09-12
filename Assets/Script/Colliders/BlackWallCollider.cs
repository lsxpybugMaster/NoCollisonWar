using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǽ��������Խ��ǽ�壬���ڶ����λ�ý������ƣ���Ҫͨ���ű��Ƴ�����
public class BlackWallCollider : MonoBehaviour
{
    public float goAwayXaxis; //��x����С��ĳʱ�����˳�ǽ��
    public float moveSpeed;
    public float moveAwayspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > goAwayXaxis)
        {
            transform.Translate(-moveSpeed * Time.deltaTime , 0 , 0);
        }
        else
        {
            transform.Translate(0, -moveAwayspeed * Time.deltaTime, 0);
        }
    }
}
