using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��ɫ�ؿ��ű��ĸ���
/*
    ���������ɫ
    �ϰ�����ɫ
 */
namespace ColorSets
{
    public enum color
    {
        red, orange, yellow, green, cyan, blue, purple
    }

}

public class ColorFather : MonoBehaviour
{
    //�洢��ɫ
    public Color[] colorPlate;
    public mode colormode;

    [HideInInspector] public float changeTime;

    public enum color
    {
        red, orange, yellow, green, cyan, blue, purple
    }

    public enum mode
    {
        rgb, rinbow
    }
}

