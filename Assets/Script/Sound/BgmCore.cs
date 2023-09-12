using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用于第一次生成音乐对象，同时防止该对象的重复初始化
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
