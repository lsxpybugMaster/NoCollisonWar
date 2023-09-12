using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ƽ��ú����õĽű�
/// </summary>
public class AbleSets : MonoBehaviour
{
    public GameObject obj;
    public float ActiveTime;
    public bool hasAble;

    // Start is called before the first frame update
    void Start()
    {
        hasAble = false;
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasAble && ActiveTime <= _GlobalTimer.t)
        {
            obj.SetActive(true);
            hasAble = true;
        }
    }
}
