using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ʾ��ҽ���
public class TrophyShower : MonoBehaviour
{
    //�����𱭺�����
    public Sprite[] trophys;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        //����˽�
        if(LevelData.levelData == 42)
        {
            sr.sprite = trophys[1];
        }
        //���������
        else if(LevelData.levelData == 41)
        {
            sr.sprite = trophys[0];
        }
        //������ʾΪ��

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
