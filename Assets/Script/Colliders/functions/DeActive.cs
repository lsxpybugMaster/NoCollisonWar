using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActive : MonoBehaviour
{
    public float deActiveTime;
    
   
    void Update()
    {
        
        if (_GlobalTimer.t > deActiveTime)
            gameObject.SetActive(false);
    }
}
