using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//���ű����ڴ�����ɫ���ϰ����Ҫ���ص��Ѿ��й��ܵ��ϰ����ϣ�������ִ��
public class ColorCollider : ColorFather
{  
    //���ڽ����������ײ��ɫ
    public color mycolor;
    
    //�Ƿ��Ǳ�ɫ�ϰ���  
    public bool changeColor;
    //����Ǳ�ɫ�ϰ�����ȥ��ɫ
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        //��ɫ�ϰ���Ĭ���ǲ���ɫ�ģ�ֻ����һ����ɫ��Ϣ
        //��ɫ�Ͳ��ظ���ɫ

        if (changeColor)
        {   
            sprite = GetComponent<SpriteRenderer>();
            
        }
    }

    void Update()
    {
        changeTime += Time.deltaTime;

        if (changeColor == true && changeTime >= 2f)
        {
            //if (colormode == mode.rgb)
            rgb();
            //TODO �� �������ܻ��������ɫ�仯
            //else: pass
        }
    }

    void rgb()
    {
        //0 -> ��  1 -> ��  2 -> �� 
        //������ɫ
        switch (mycolor)
        {
            case color.red:
                change_color(1) ;  mycolor = color.green; break;
            case color.green:
                change_color(2) ;  mycolor = color.blue ; break;
            case color.blue:
                change_color(0) ;  mycolor = color.red   ; break;
        }
        //������ɫָʾ����������ʱ��  
        changeTime = 0;
    }

    void change_color(int idx)
    {   
         sprite.color = colorPlate[idx];   
    }

}
