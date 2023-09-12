using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashMoveCollider : MonoBehaviour
{
    public float activeTime;

    public float distance;

    public float flashInterval;
    
    [SerializeField] Vector3 MoveTarget;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FlashMove",activeTime,flashInterval);
        
        Vector3.Normalize(MoveTarget);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FlashMove()
    {
        transform.Translate(MoveTarget * distance);
    }
}
