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
        /// ����ά������zֵ����������2d��Ϸ
        /// </summary>
        /// <param name="v">�����2d�������ά����</param>
        public static Vector3 Pos2D(Vector3 v)
        {
            v.z = 0f;
            return v;
        }
    }
}