using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    void Awake()
    {
        // 保持该游戏对象不被销毁
        DontDestroyOnLoad(this.gameObject);
    }

    //调用位置 ： 通关，跳关，退出到界面
    public void DestroySound()
    {
        // 手动销毁对象防止对象重复
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
