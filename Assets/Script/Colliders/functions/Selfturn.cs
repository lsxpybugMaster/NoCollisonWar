using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 控制物体自转的脚本
 */
public class Selfturn : MonoBehaviour
{
    [SerializeReference] private float speed;
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
