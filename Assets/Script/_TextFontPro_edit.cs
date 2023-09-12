using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class _TextFontPro_edit : MonoBehaviour
{
    TextMeshPro Text;

    // Start is called before the first frame update
    private void Awake()
    {
        Text = transform.GetComponent<TextMeshPro>();
    }
    // Update is called once per frame
    void Update()
    {
        Text.text = 99.ToString();
    }
}
