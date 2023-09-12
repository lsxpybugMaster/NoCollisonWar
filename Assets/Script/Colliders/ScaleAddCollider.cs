using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//�����
public class ScaleAddCollider : MonoBehaviour
{
    public float speed;
    public float maxScale;
    public float activeTime;

    //�����¼�
    public UnityEvent shootEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_GlobalTimer.t > activeTime)
        {
            float new_x = transform.localScale.x + speed * Time.deltaTime;
            transform.localScale = new Vector3(new_x, transform.localScale.y, transform.localScale.z);

            if (new_x > maxScale)
            {
                shootEvent.Invoke();
                Destroy(gameObject);
            }
        }
    }


}
