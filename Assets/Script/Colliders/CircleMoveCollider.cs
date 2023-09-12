using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoveCollider : MonoBehaviour
{
    [Header("绕中心移动的半径")]
    [SerializeField] private float r;
    [SerializeField] private float speed;
    [SerializeField] private Transform circle;

    
    // Start is called before the first frame update
    void Start()
    {
        circle.transform.localPosition = new Vector3(r, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,speed * Time.deltaTime);
    }
}
