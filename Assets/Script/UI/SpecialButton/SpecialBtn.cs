using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialBtn : MonoBehaviour
{
    public float triggerDistance;

    public UnityEvent function;

    void Start()
    {
        
    }

    
    void Update()
    {
        float dis = Vector2.Distance(PlayerController.instance.transform.position, transform.position);
        if (dis < triggerDistance)
        {
            function.Invoke();
        }
    }
}
