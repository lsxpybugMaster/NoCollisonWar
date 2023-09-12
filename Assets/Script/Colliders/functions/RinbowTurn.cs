using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 控制物体自转的脚本
 */


public class RinbowTurn : MonoBehaviour
{
    public float speed;
    //最大速度
    public float maxspeed;
    //到达最大速度时的时间
    public float timeNeed;
    //计算出平均每秒加多少速度
    float delta;
  
    // Start is called before the first frame update
    void Start()
    {
        delta = (maxspeed - speed) / timeNeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < maxspeed)
        {
            speed += delta * Time.deltaTime;
        }   
        transform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
    }
}
