using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamOfMenu : MonoBehaviour
{
    public Transform playerTransform;

    public float LerpT;

    public float followLimitLeft;
    public float followLimitRight;

    float xTmp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xTmp = Mathf.Lerp(transform.position.x, playerTransform.position.x, Time.deltaTime * LerpT);                       
        xTmp = Mathf.Clamp(xTmp, followLimitLeft, followLimitRight);
        
        transform.position = new Vector3(xTmp, transform.position.y, transform.position.z);
    }

    void Reset()
    {
        transform.position = Vector3.zero;
    }

}
