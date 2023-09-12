using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gua_Collider : MonoBehaviour
{
    //开始移动卦线的时间
    [SerializeReference] private float act_time;

    const float DISTANCE = 20f;

    //是否进入过if
    bool not_in_if = true;
   

    void Start()
    {
        //先让各个卦象移动到对侧卦象部分
        transform.Translate(new Vector3(0, DISTANCE, 0),Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        if (_GlobalTimer.t > act_time && not_in_if )
        {
            StartCoroutine("act_now");
            not_in_if = false;
        }
    }

    //启动协程后，每隔2.5s释放一个卦线
    IEnumerator act_now()
    {
        int count = 0;
        while (count < 3)
        {
            transform.GetChild(count).GetComponent<Gua_xian_Collider>().canMove = true;
            yield return new WaitForSeconds(2.5f);
            count++;
        }
    }
    
}

