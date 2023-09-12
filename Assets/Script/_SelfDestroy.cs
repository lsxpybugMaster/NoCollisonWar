using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SelfDestroy : MonoBehaviour
{
    public float destroyTime;
    private float T = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        T += Time.deltaTime;
        if(T > destroyTime)
            Destroy(gameObject);
    }
}
