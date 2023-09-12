using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedFuction : MonoBehaviour
{
    //获取spriteRenderer以更改颜色
    public SpriteRenderer[] SR;
    public Color damagedColor;
    public float flashTime;

    WaitForSeconds waitForSeconds;

    // Start is called before the first frame update
    void Start()
    {
        waitForSeconds = new WaitForSeconds(flashTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damagedFlashFuction()
    {
        foreach (var sr in SR)
        {
            sr.color = damagedColor;
        }

        StartCoroutine(BackNormalColor());
    }

    IEnumerator BackNormalColor()
    {
        yield return waitForSeconds;

        foreach (var sr in SR)
        {
            sr.color = Color.white;
        }
    }
}
