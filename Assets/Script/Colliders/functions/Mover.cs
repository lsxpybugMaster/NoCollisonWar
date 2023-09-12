using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//���ڽ�ĳЩ�������ϰ������룬����λ�ú���Եȴ�һ��ʱ������ź�
public class Mover : MonoBehaviour
{
    //����ֱ���ƶ��������
    [SerializeReference] Transform[] pos;
    [SerializeReference] float speed;
    [SerializeReference] float rotateSpeed;
    [SerializeReference] bool NotRotate;

    //ʲôʱ�򼤻������Ͳ�����
    public float Activetime;
    //�ȴ�ʱ��
    public float waitTime;

    //�����¼�
    public UnityEvent actEvent;

    bool reach = false;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 120;
        if (NotRotate)
            rotateSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reach)
        {
            moveToPosition();
            selfRotate();
        }

        // ����Ӷ�������
        if (transform.childCount == 0)
        {
            Destroy(transform.parent.gameObject); //���Ӷ��󣨼��������ϰ������ʱ��ͬʱ����һ���׶���
            //�������ܿո�����mover��tar
        }
    }

    void moveToPosition()
    {
        //һ�����жϻʱ���Ƿ�Ϊ0  �������˵�����ֶ����Ƽ���ʱ�䣬��ùؿ�һ��������_GlobalTimer
        if (Activetime == 0 || Activetime < _GlobalTimer.t)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos[index].position, speed * Time.deltaTime);
            //���ǳ��ӽ���Ӧλ��ʱ���л�Ŀ��

            if ((pos[index].position - transform.position).magnitude < 0.2f)
            {
                //���δ��������λ�ã�������index����������һλ��
                if (index < pos.Length - 1)
                    index++; //index����                
                //����˵���Ѿ���������λ�ã�׼��ִ���¼�
                else
                {
                    reach = true;
                    StartCoroutine(activeEventwithDelay());
                }  
            }
        }
    }

    //Ͷ��ʱ��ת
    void selfRotate()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private IEnumerator activeEventwithDelay()
    {
        yield return new WaitForSeconds(waitTime); // �ȴ�ʱ��
        //�����¼����ȴ���Ӧʵ����Ӧ
        actEvent.Invoke();
    }
}
