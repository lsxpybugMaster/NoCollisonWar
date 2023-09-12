using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//简单全局计时器
public class _GlobalTimer : MonoBehaviour
{
    //全局计时器下的全局时间
    public static float t;

    [SerializeField] float timeSet = 0;   //可以手动设置初始时间用于测试

    //public static bool seeTurial = false;  //public static 变量即使场景重开也不会重置！
    void Start()
    {
        //在start中初始化，以防重新开始场景时time未被清零
        t = timeSet;
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;              
    }

 
}
