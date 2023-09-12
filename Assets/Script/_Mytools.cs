using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mytools
{
    public class printf : MonoBehaviour
    {
   
        public static void orange(string str)
        {
            Debug.Log("<color=orange>"+str+"</color>");
        }
        public static void green(string str)
        {
            Debug.Log("<color=green>" + str + "</color>");
        }
        public static void blue(string str)
        {
            Debug.Log("<color=#00EEFF>" + str + "</color>");
        }
    }

    public class Tool2D : MonoBehaviour
    {
        /// <summary>
        /// 将三维向量的z值归零以用于2d游戏
        /// </summary>
        /// <param name="v">传入的2d对象的三维向量</param>
        public static Vector3 Pos2D(Vector3 v)
        {
            v.z = 0f;
            return v;
        }
    }
}