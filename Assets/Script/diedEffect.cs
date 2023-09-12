using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制Mask以展现死亡复活效果
public class diedEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float alpha;
    //private bool has_changed_alpha;
    
    // Start is called before the first frame update
    void Start()
    {
        // has_changed_alpha = false;
        alpha = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (alpha > 0f)
        {
            alpha -= Time.deltaTime;         
        }
        else
        {
            alpha = 0;    
        }
        
        spriteRenderer.color = new Color(0f, 0f, 0f, alpha);
        
    }

    
}
