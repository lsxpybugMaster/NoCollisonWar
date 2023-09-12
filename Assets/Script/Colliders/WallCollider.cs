using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ϸ�ڲ�ǽ��ű�����������ת����״̬ʱ��ɫ
public class WallCollider : MonoBehaviour
{
    //��ת
    public float startRotateTime;
    public float rotateAngle;
    public float rotateSpeed;

    float rotateAngleNow;
    float add;

    //��ɫ�任
    public Color targetColor = Color.blue;
    public float transitionDuration = 2.0f;

    Color startColor;
    SpriteRenderer spriteRenderer;

    bool hasChangedColor;

    private void Start()
    {
        hasChangedColor = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        
    }

    void Update()
    {
        if (_GlobalTimer.t > startRotateTime)
        {
            RotateMe();
            if(!hasChangedColor)
                StartCoroutine(TransitionColor());
        }

    }
    private IEnumerator TransitionColor()
    {
        hasChangedColor = false;
        float elapsedTime = 0.0f;
        Color currentColor = startColor;

        while (elapsedTime < transitionDuration)
        {
            // ���㵱ǰ��ɫ����startColor��targetColor�Ĳ�ֵ��
            currentColor = Color.Lerp(startColor, targetColor, elapsedTime / transitionDuration);

            // ���¶������ɫ
            spriteRenderer.color = currentColor;

            // �ȴ�һ֡
            yield return null;

            // �����Ѿ���ȥ��ʱ��
            elapsedTime += Time.deltaTime;
        }

        // ȷ��������ɺ�������ɫ��Ŀ����ɫ

        spriteRenderer.color = targetColor;
    }

    void RotateMe()
    {
        add = Time.deltaTime * rotateSpeed;
        rotateAngleNow += add;
        if (rotateAngleNow < rotateAngle)
            transform.Rotate(0, 0, add);
    }
}
