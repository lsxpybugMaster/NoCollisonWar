using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoad : MonoBehaviour
{
    //ÿ�ν������˵��������Զ�����
    void Awake()
    {
        //�����ȡ���ݷ�ֹ�޷�����
        LevelData.Load();
    }

    private void Start()
    {
        //��Ϊ0ʱ����̳�
        if(LevelData.levelData == 0)
        {
            BgmCore.StopBgm();
            SceneManager.LoadScene("Tutorial");
        }
    }
}
