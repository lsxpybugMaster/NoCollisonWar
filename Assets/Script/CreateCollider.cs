using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ײ��Ľڵ㣬Ŀǰ��һ����ײ��
public class CreateCollider : MonoBehaviour
{
    [SerializeReference] private GameObject pf_collider;
    [SerializeReference] private float startCreateTime;
    [SerializeReference] private float createTimeInterval;
    // Start is called before the first frame update
    void Start()
    {   
        InvokeRepeating("Create",startCreateTime,createTimeInterval);           
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    void Create()
    {
        Instantiate(pf_collider);
        pf_collider.transform.position = transform.position;
        
    }

}
