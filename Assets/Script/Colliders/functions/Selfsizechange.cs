using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfsizechange : MonoBehaviour
{
    [SerializeReference] private Vector3 scale;
    [SerializeReference] private float startChangeTime;
    [SerializeReference,Header("Lerp ÊýÖµ")] private float changeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_GlobalTimer.t >startChangeTime)
            transform.localScale = Vector3.Lerp(transform.localScale, scale , changeSpeed * Time.deltaTime);
    }
}
