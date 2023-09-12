using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//脉冲变换器，物体的X scale会在A 与 B之间脉冲
public class ImpluseChange : MonoBehaviour
{
    [SerializeField] public float min_x;
    [SerializeField] public float max_x;
    [SerializeField] public float addSpeed;
    int add;

    // Start is called before the first frame update
    void Start()
    {
        add = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //大小先加后减
        float x = transform.localScale.x;
        if(x >= max_x)       
            add = -1;
        if (x <= min_x)
            add = 1;

        float newx = transform.localScale.x + add * addSpeed * Time.deltaTime;
        transform.localScale = new Vector3(newx, transform.localScale.y, transform.localScale.z);
    }
}
