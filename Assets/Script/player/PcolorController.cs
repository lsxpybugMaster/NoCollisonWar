using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  TODO�� ����ṹ��������Ҫ�޸�
    FIXME : ����ṹ��������Ҫ�޸�
 */

//�ı������ɫ�Ľű�,�̳��Ը���
public class PcolorController : ColorFather
{
    public SpriteRenderer[] playerSprites;
    //���ڽ����������ײ��ɫ
    public static int colorCode;

    // Start is called before the first frame update
    void Start()
    {
        changeTime = 0;
        colorCode = 0;
        //��ʼ��Ĭ����ɫ
        change_color(colorCode);
    }

    // Update is called once per frame
    void Update()
    {
        changeTime += Time.deltaTime;

        if (changeTime >= 2f)
        {
            if (colormode == mode.rgb)
                rgb();
            else
                rinbow();
        } 
    }

    void rgb()
    {
        //������ɫ
        switch(colorCode)
        {              
            case (int)color.red:
                change_color((int)color.green); colorCode = (int)color.green;  break;
            case (int)color.green:
                change_color((int)color.blue);  colorCode = (int)color.blue;  break;
            case (int)color.blue:
                change_color((int)color.red); colorCode = (int)color.red; break;
        }
        //������ɫָʾ����������ʱ��  
        changeTime = 0;
    }

    void rinbow()
    {
        //������ɫָʾ����������ʱ�� [7 : �ʺ���ɫ]
        colorCode = (colorCode + 1) % 7;
        changeTime = 0;

        //������ɫ
        change_color(colorCode);  
    }

    void change_color(int idx)
    {
        for (int i = 0; i < playerSprites.Length; i++)
        {
            playerSprites[i].color = colorPlate[idx];
        }
    }

}
