using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ڵ�һ���������ֶ���ͬʱ��ֹ�ö�����ظ���ʼ��
public class BgmCore : MonoBehaviour
{
    public GameObject bgm;

    void Awake()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Bgm");
        if(music == null)
        {
            Instantiate(bgm);
        }
        else
        {
            Debug.Log("already have");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void StopBgm()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Bgm");
        Destroy(music);
    }
}
