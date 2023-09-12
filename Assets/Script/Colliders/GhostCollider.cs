using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollider : MonoBehaviour
{
    [SerializeField] float activeTime;
    [SerializeField] float speed;
    [SerializeField] float colorDecreaseSpeed; //色彩降低速度
    [SerializeField] Transform stealthPoint; //到达此点开始隐身
    [SerializeField] Transform visablePoint; //到达此点解除隐身
    [SerializeField] Vector3 MoveTarget;
    bool isStealth;
    bool hasStealthed;

    [SerializeField]bool DEBUG;
    // bool nearPlayer; //靠近玩家时，采用另一套策略

    Color color;
    SpriteRenderer SR;
    float alpha; //色彩透明度

    // Start is called before the first frame update
    void Start()
    {
        isStealth = false;
        hasStealthed = false;
        //nearPlayer = false;

        SR = GetComponent<SpriteRenderer>();     
        color = SR.color;

        alpha = 1.0f;

        colorDecreaseSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_GlobalTimer.t >= activeTime)
        {
            CheckTwoPoints();
            if(!DEBUG)
                CheckStealth();
            Move();
            
        }
    }

    void CheckTwoPoints()
    {
        if(!hasStealthed && Vector2.Distance(transform.position, stealthPoint.position) < 0.1f)
        {
            hasStealthed = true;
            isStealth = true;
        }

        if(hasStealthed && Vector2.Distance(transform.position,visablePoint.position) < 0.1f)
        {
            isStealth = false ;
        }
    }


    //检测隐身状态，如果是隐身状态则隐身
    void CheckStealth()
    {
        //隐身状态下逐渐减小颜色透明度
        if(isStealth)
        { 
            alpha -= colorDecreaseSpeed * Time.deltaTime;
            if(alpha < 0.0f) alpha = 0.0f;
            SR.color = new Color(color.r, color.g, color.b, alpha);
        }
        //如果不是隐身状态并且还已经隐过身了，则增加透明度
        else if(hasStealthed)
        {
            alpha += colorDecreaseSpeed * Time.deltaTime;
            if (alpha > 1.0f) alpha = 1.0f;
            SR.color = new Color(color.r, color.g, color.b, alpha);
        }
    }

    void Move()
    {
        transform.Translate(MoveTarget * speed * Time.deltaTime);
    }

    //void CheckPlayer()
    //{
      
    //    if(Vector2.Distance(PlayerController.static_transform.position, transform.position) < 2f)
    //    {
    //        nearPlayer = true;
    //        SR.color = new Color(color.r, color.g, color.b, 1);
    //    }
    //    else
    //    {
    //        nearPlayer = false;
    //    }
    //}
}
