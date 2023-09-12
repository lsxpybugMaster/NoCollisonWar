using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuBtn : MonoBehaviour
{
    public float distance;

    public UnityEvent function;

    public Transform player;

    void Update()
    {
        float dis = Vector2.Distance(player.position, transform.position);
        if (dis < distance)
        {
            function.Invoke();
        }
    }
}
