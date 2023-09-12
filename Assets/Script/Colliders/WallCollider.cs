using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏内部墙体脚本，可以在旋转成新状态时变色
public class WallCollider : MonoBehaviour
{
    //旋转
    public float startRotateTime;
    public float rotateAngle;
    public float rotateSpeed;

    float rotateAngleNow;
    float add;

    //颜色变换
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
            // 计算当前颜色（从startColor到targetColor的插值）
            currentColor = Color.Lerp(startColor, targetColor, elapsedTime / transitionDuration);

            // 更新对象的颜色
            spriteRenderer.color = currentColor;

            // 等待一帧
            yield return null;

            // 更新已经过去的时间
            elapsedTime += Time.deltaTime;
        }

        // 确保过渡完成后，最终颜色是目标颜色

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
