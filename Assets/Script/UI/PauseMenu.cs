using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //用于启用和禁用暂停UI界面
    public GameObject PauseUI;

    //启动菜单时忽略死亡黑暗特效,自动获取
    GameObject Mask;

    //用于跳关，自动推断
    int levelNumber;

    private void Start()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        Mask = GameObject.FindGameObjectWithTag("Mask");
    }

    #region 菜单的打开与关闭 , InputSystemFuctions
    public void PauseFunction(InputAction.CallbackContext context)
    {
        //按下了对应按键
        if (context.started && !PlayerController.instance.isPaused)
        {
            //Debug.Log("Pause");

            Time.timeScale = 0;

            PlayerController.instance.isPaused = true;
       
            PauseUI.SetActive(true);
            Mask.SetActive(false);
        }
    }

    public void PlayFunction(InputAction.CallbackContext context)
    {       
        //按下了对应按键
        if (context.started)
        {
            //Debug.Log("Restart");

            ContinueGameFunction();
        }
    }
    #endregion

    #region 按钮调用的函数

    //继续游戏（按Esc也可调用）
    public void ContinueGameFunction()
    {
        Time.timeScale = 1;

        PlayerController.instance.isPaused = false;

        PauseUI.SetActive(false);
        Mask.SetActive(true);
    }

    //退出
    public void QuitGame()
    {
        Application.Quit();
    }

    //返回主菜单
    public void returnToTitle()
    {
        Time.timeScale = 1;
    
        BgmCore.StopBgm();

        SceneManager.LoadScene("Title");
    }

    //跳关选项
    public void ToNextLevel()
    {
        Time.timeScale = 1;
        //如果通过的是最新关卡，则解锁新关卡
        if (levelNumber == LevelData.levelData)
        {
            Debug.Log("Jump to new level!!!");
            LevelData.levelData++;
            //解锁新关卡后保存数据
            LevelData.Save();
        }

        BgmCore.StopBgm();
        //自动跳转到下一个编号的关卡
        SceneManager.LoadScene(levelNumber + 1);
    }

    #endregion
}
