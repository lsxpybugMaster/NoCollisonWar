using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//显示玩家奖杯
public class TrophyShower : MonoBehaviour
{
    //包含金杯和银杯
    public Sprite[] trophys;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        //获得了金杯
        if(LevelData.levelData == 42)
        {
            sr.sprite = trophys[1];
        }
        //获得了银杯
        else if(LevelData.levelData == 41)
        {
            sr.sprite = trophys[0];
        }
        //否则显示为空

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
