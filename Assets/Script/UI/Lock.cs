using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    //被锁住的对象
    public GameObject lockedObj;
    //锁住的关卡
    public int theLevel;

    void Start()
    {
        if(theLevel <= LevelData.levelData)
        {
            lockedObj.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
