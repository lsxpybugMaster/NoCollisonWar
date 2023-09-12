using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//存储一系列按钮调用的函数
public class Buttonfunctions : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameFast()
    {
        int now = LevelData.levelData;

        if (now <= 40 && now >= 1)
        {
            BgmCore.StopBgm();
            SceneManager.LoadScene(LevelData.levelData);
        }
        //通关之后只会进入最后一关
        else if(now > 40)
        {
            BgmCore.StopBgm();
            SceneManager.LoadScene(40);
        }
    }

    public void FinishTutorial()
    {
        //通过了教程关，leveldata从0变1
        
        LevelData.levelData++;            
        LevelData.Save();
        
        BgmCore.StopBgm();

        SceneManager.LoadScene("Title");
    }

    //获取金杯
    public void GainGoldenMetal()
    {
        //如果当前关卡信息不为42，说明是第一次获取金杯，否则不再更改
        if (LevelData.levelData != 42)
        {
            LevelData.levelData = 42;
            //获取金杯后保存数据
            LevelData.Save();
        }

        BgmCore.StopBgm();

        SceneManager.LoadScene("Title");
    }
    
}
