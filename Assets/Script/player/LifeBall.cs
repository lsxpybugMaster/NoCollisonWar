using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBall : MonoBehaviour
{
    public float moveAwaySpeed;

    bool canGoAway;

    void Start()
    {
        canGoAway = false;
    }

    void Update()
    {
        if(canGoAway)
        {
            GoAway();
        }
    }

    public void DisableMe()
    {
        canGoAway = true;
    }

    void GoAway()
    {       
        if(transform.position.y < -10)
        {
            this.gameObject.SetActive(false);
        }

        transform.Translate(0,-moveAwaySpeed * Time.deltaTime,0);
    }

}
