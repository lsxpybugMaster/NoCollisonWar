using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TraceFollowCollider : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 10;
    [SerializeField] float minAlpha , liveTime;  //通过计算时间获得百分比，由此去减小透明度
    [SerializeField] float activeTime;

    Color color;
    SpriteRenderer SR;
    BoxCollider2D box2d;
    float timer;
    float destroyTimeDelay;

    // Start is called before the first frame update
    void Start()
    {
        // transform.up = PlayerController.static_transform.position - transform.position;
        SR = GetComponent<SpriteRenderer>();
        box2d = GetComponent<BoxCollider2D>();
        color = SR.color;

        timer = 0;
        destroyTimeDelay = liveTime * 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_GlobalTimer.t >= activeTime)
        {

            if (timer >= liveTime)
            {
                box2d.enabled = false;
                Destroy(gameObject, destroyTimeDelay);
            }

            timer += Time.deltaTime;

            transform.up = PlayerController.static_transform.position - transform.position;
            transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);

            float alpha = (1 - timer / liveTime) * (1 - minAlpha) + minAlpha;
            SR.color = new Color(color.r, color.g, color.b, alpha);

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
