using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ģ�⼤��Ľű���ʵ�ִ�һ��ϸ�ߵ��ּ���Ȼ����ʧ�Ĺ���
public class LaserCollider : MonoBehaviour
{
    //������
    float laserWidth;
    //��չ�ٶ�
    public float spreadSpeed;
    //���˺��Ŀ��
    public float dangerWidth;

    //�ӳ����ٵ�ʱ��
    float destroyDelayTime;

    BoxCollider2D myCollider;
    //�����ж��Ƿ�ִ���¼�
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.enabled = false;
        laserWidth = 1;
        destroyDelayTime = 0.15f;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
            Laser();
    }

    void Laser()
    {
        // ��չ�����ȣ�����һ�����ʱ������ײ��

        float width = transform.localScale.y + spreadSpeed * Time.deltaTime;
        //�������
        if (width > laserWidth)
        {
            width = laserWidth;

            Destroy(transform.parent.gameObject,destroyDelayTime);
        }
        //����һ�����ʱ������ײ��
        else if (width > dangerWidth)
            myCollider.enabled = true;
        transform.localScale = new Vector3(transform.localScale.x, width, transform.localScale.z);
    }

    /// <summary>
    /// Listener : ר������Ӧ�������¼�
    /// </summary>
    //�����ź��¼�ִ�д˺���
    public void Activeshoot()
    {
        active = true;
    }
}
