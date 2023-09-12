using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //�������úͽ�����ͣUI����
    public GameObject PauseUI;

    //�����˵�ʱ���������ڰ���Ч,�Զ���ȡ
    GameObject Mask;

    //�������أ��Զ��ƶ�
    int levelNumber;

    private void Start()
    {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        Mask = GameObject.FindGameObjectWithTag("Mask");
    }

    #region �˵��Ĵ���ر� , InputSystemFuctions
    public void PauseFunction(InputAction.CallbackContext context)
    {
        //�����˶�Ӧ����
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
        //�����˶�Ӧ����
        if (context.started)
        {
            //Debug.Log("Restart");

            ContinueGameFunction();
        }
    }
    #endregion

    #region ��ť���õĺ���

    //������Ϸ����EscҲ�ɵ��ã�
    public void ContinueGameFunction()
    {
        Time.timeScale = 1;

        PlayerController.instance.isPaused = false;

        PauseUI.SetActive(false);
        Mask.SetActive(true);
    }

    //�˳�
    public void QuitGame()
    {
        Application.Quit();
    }

    //�������˵�
    public void returnToTitle()
    {
        Time.timeScale = 1;
    
        BgmCore.StopBgm();

        SceneManager.LoadScene("Title");
    }

    //����ѡ��
    public void ToNextLevel()
    {
        Time.timeScale = 1;
        //���ͨ���������¹ؿ���������¹ؿ�
        if (levelNumber == LevelData.levelData)
        {
            Debug.Log("Jump to new level!!!");
            LevelData.levelData++;
            //�����¹ؿ��󱣴�����
            LevelData.Save();
        }

        BgmCore.StopBgm();
        //�Զ���ת����һ����ŵĹؿ�
        SceneManager.LoadScene(levelNumber + 1);
    }

    #endregion
}
