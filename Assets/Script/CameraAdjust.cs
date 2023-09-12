using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    public float initOrthoSize = 5;
    public float initWidth = 1920;
    public float initHeight = 1080;
    float factOrthoSize;
    float factWidth;
    float factHeight;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Unity3D自带的适配系统仅保持高度适配，一下代码是宽度适配 注意！仅正交相机可用
        factWidth = Screen.width;
        factHeight = Screen.height;
        //实际视口 = 初始视口 * 初始高宽比 / 实际宽高比
        factOrthoSize = (initOrthoSize * (initWidth / initHeight)) / (factWidth / factHeight);
        GetComponent<Camera>().orthographicSize = factOrthoSize;
    }
}
