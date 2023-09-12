using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoad : MonoBehaviour
{
    //每次进入主菜单都进行自动读档
    void Awake()
    {
        //尽早读取数据防止无法解锁
        LevelData.Load();
    }

    private void Start()
    {
        //当为0时进入教程
        if(LevelData.levelData == 0)
        {
            BgmCore.StopBgm();
            SceneManager.LoadScene("Tutorial");
        }
    }
}
