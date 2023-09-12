using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ŀ��ű�������ƶ���Ŀ���һ��λ����ͨ��
//ע���Ŀ�겻�����ڽ̳̹ؼ�ͨ�ؽ�
public class Target : MonoBehaviour
{
    enum Usage
    {
        Win,  //��Ϊͨ�ط���
        LevelSwitch, //��Ϊ�л��ؿ�����
    }

    [Header("��Ŀ������ɵĹ���")]
    [SerializeField] private Usage usage;

    [Header("������л�Ŀ�������л����ĳ�����")]
    [SerializeField] private string level = "";

    //�ؿ���ţ��Զ��Ƶ�
    int levelNumber;

   
    void Start()
    {       
        //�Զ��ƶ�levelNumber��Ϊbuild������
        levelNumber = SceneManager.GetActiveScene().buildIndex;     
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(PlayerController.static_transform.position, transform.position);
        if (dis < 0.2f)
        {
            //���ݹ��ܵ��ú���
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

    //������1-40��ͨ�أ��𱭲���
    //40��ͨ�غ���ʾ�ؿ���ϢΪ41����ʱ��������
    void win()
    {
        
        //���ͨ���������¹ؿ���������¹ؿ�
        if(levelNumber == LevelData.levelData)
        {
            LevelData.levelData++;
            //�����¹ؿ��󱣴�����
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
