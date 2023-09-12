using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//对于某些不可越过的限制性墙体，需要通过此脚本运出（默认向下运出）
public class MoveAway : MonoBehaviour
{
    public float goAwayXaxis; //当x坐标小于某时，则运出墙体
    public float speed;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= goAwayXaxis)
        {
            transform.Translate(0,-speed * Time.deltaTime,0);
        }
    }
}
