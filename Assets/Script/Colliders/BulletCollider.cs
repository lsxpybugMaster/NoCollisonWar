using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ӵ���ײ�壬�����źź���
public class BulletCollider : MonoBehaviour
{
    bool active = false;
    [SerializeField] float MoveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
    }

    //�����ź�ִ�д˺���
    public void Activeshoot()
    {
        active = true;
    }
}
