using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�洢һϵ�а�ť���õĺ���
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
        //ͨ��֮��ֻ��������һ��
        else if(now > 40)
        {
            BgmCore.StopBgm();
            SceneManager.LoadScene(40);
        }
    }

    public void FinishTutorial()
    {
        //ͨ���˽̳̹أ�leveldata��0��1
        
        LevelData.levelData++;            
        LevelData.Save();
        
        BgmCore.StopBgm();

        SceneManager.LoadScene("Title");
    }

    //��ȡ��
    public void GainGoldenMetal()
    {
        //�����ǰ�ؿ���Ϣ��Ϊ42��˵���ǵ�һ�λ�ȡ�𱭣������ٸ���
        if (LevelData.levelData != 42)
        {
            LevelData.levelData = 42;
            //��ȡ�𱭺󱣴�����
            LevelData.Save();
        }

        BgmCore.StopBgm();

        SceneManager.LoadScene("Title");
    }
    
}
