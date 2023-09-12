using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//黑墙即不可逾越的墙体，用于对玩家位置进行限制，需要通过脚本移除场景
public class BlackWallCollider : MonoBehaviour
{
    public float goAwayXaxis; //当x坐标小于某时，则运出墙体
    public float moveSpeed;
    public float moveAwayspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > goAwayXaxis)
        {
            transform.Translate(-moveSpeed * Time.deltaTime , 0 , 0);
        }
        else
        {
            transform.Translate(0, -moveAwayspeed * Time.deltaTime, 0);
        }
    }
}
