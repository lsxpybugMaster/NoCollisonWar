using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//从原位走到0再走到1
public class TwoPointMoveCollider : MonoBehaviour
{
    [SerializeReference] Transform[] pos;
    [SerializeReference] float speed;
    
    int index = 0;
  
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position , pos[index].position , speed * Time.deltaTime);
        //当非常接近对应位置时，切换目标

        if ((pos[index].position - transform.position).magnitude < 0.2f)
            index ^= 1; //index可以在0,1之间任意切换
    }
}

