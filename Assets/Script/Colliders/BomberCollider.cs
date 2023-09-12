using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�ı����Ĵ�С��͸���ȣ�ģ�ⱬը
public class BomberCollider : MonoBehaviour
{
    public float scaleSpeed = 0.5f;     // �Ŵ��ٶ�
    public float alphaSpeed = 0.5f;     // ͸���ȱ仯�ٶ�
    public float targetScale = 2f;      // Ŀ��ߴ�(����)
    public float targetAlpha = 0f;      // Ŀ��͸����

    private Vector3 initialScale;        // ��ʼ�ߴ�
    private Color initialColor;          // ��ʼ��ɫ
    private Renderer myrenderer;           // ��Ⱦ��
    Vector3 e;

    //����
    bool active = false;

    void Start()
    {
        initialScale = transform.localScale;
        myrenderer = GetComponent<Renderer>();
        if (myrenderer != null)
        {
            initialColor = myrenderer.material.color;
        }

        e = new Vector3(1,1,1);
    }

    void Update()
    {
        //�յ�moverͶ�������źź󼤻�
        if (active)
        {
            // �ı�ߴ�(���ٸı�)
            if (transform.localScale.x < targetScale)
            {
                transform.localScale += scaleSpeed * Time.deltaTime * e;
            }
            else //�ߴ�ﵽ�����ɢ
            {
                Destroy(gameObject);
            }

            // �ı�͸����
            if (myrenderer != null)
            {
                float nowAlpha = myrenderer.material.color.a;

                float newAlpha = Mathf.Lerp(nowAlpha, targetAlpha, alphaSpeed * Time.deltaTime);
                myrenderer.material.color = new Color(initialColor.r, initialColor.g, initialColor.b, newAlpha);
            }
        }
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
