using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//目标脚本，玩家移动到目标的一定位置则通关
//注意此目标不适用于教程关及通关金杯
public class Target : MonoBehaviour
{
    enum Usage
    {
        Win,  //作为通关方块
        LevelSwitch, //作为切换关卡方块
    }

    [Header("此目标所完成的功能")]
    [SerializeField] private Usage usage;

    [Header("如果是切换目标则所切换到的场景名")]
    [SerializeField] private string level = "";

    //关卡编号，自动推导
    int levelNumber;

   
    void Start()
    {       
        //自动推断levelNumber，为build中数据
        levelNumber = SceneManager.GetActiveScene().buildIndex;     
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(PlayerController.static_transform.position, transform.position);
        if (dis < 0.2f)
        {
            //根据功能调用函数
            switch (usage)
            {
                case Usage.Win:
                    win();
                    break;
                case Usage.LevelSwitch:
                    levelSwitch();
                    break;
            }

        }
    }

    //仅限于1-40关通关，金杯不算
    //40关通关后，显示关卡信息为41，此时生成银杯
    void win()
    {
        
        //如果通过的是最新关卡，则解锁新关卡
        if(levelNumber == LevelData.levelData)
        {
            LevelData.levelData++;
            //解锁新关卡后保存数据
            LevelData.Save();
        }

        BgmCore.StopBgm();

        SceneManager.LoadScene("Title");
    }

    void levelSwitch()
    {
       
        BgmCore.StopBgm();

        SceneManager.LoadScene(level);
    }
}
