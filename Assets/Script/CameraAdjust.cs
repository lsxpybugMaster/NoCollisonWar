using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    public float initOrthoSize = 5;
    public float initWidth = 1920;
    public float initHeight = 1080;
    float factOrthoSize;
    float factWidth;
    float factHeight;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Unity3D�Դ�������ϵͳ�����ָ߶����䣬һ�´����ǿ������ ע�⣡�������������
        factWidth = Screen.width;
        factHeight = Screen.height;
        //ʵ���ӿ� = ��ʼ�ӿ� * ��ʼ�߿�� / ʵ�ʿ�߱�
        factOrthoSize = (initOrthoSize * (initWidth / initHeight)) / (factWidth / factHeight);
        GetComponent<Camera>().orthographicSize = factOrthoSize;
    }
}
