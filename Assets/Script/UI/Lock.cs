using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    //����ס�Ķ���
    public GameObject lockedObj;
    //��ס�Ĺؿ�
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
