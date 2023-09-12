using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//给一条阴卦/阳卦所使用的移动，让其沿自己的位置移动一段距离后停止
public class Gua_xian_Collider : MonoBehaviour
{
    [SerializeReference] private float speed;
    //供父对象调用
    [HideInInspector] public bool canMove = false;

    //经计算后所有卦线应当移动的距离
    const float DISTANCE = 20f;
    
    //计算距离
    float distance = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //如果父对象修改了canMove，则该卦会对应移动指定距离后停止
        if(canMove && distance < DISTANCE)
        {
            float deltaDistance = speed * Time.deltaTime;
            distance += deltaDistance;
            transform.Translate(0, -deltaDistance,0,Space.Self);
        }
    }

   
}
