using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem 
{
    /// <summary>
    /// �洢����
    /// </summary>
    /// <param name="saveFileName">�浵·��</param>
    /// <param name="data">�洢�����л����ݣ��Ƽ����л����ࣩ</param>
    public static void SaveByJson(string saveFileName,object data)
    {
        //Ҫ�� object data �����л� 
        var json = JsonUtility.ToJson(data);
        //ʹ��Application.persistentDataPath��ʹ�ô浵·��������ƽ̨����Ӧ
        var path = Path.Combine(Application.persistentDataPath,saveFileName);

        try
        {
            //�˺����Ḳ��д��
            File.WriteAllText(path,json);

            #if UNITY_EDITOR
            Debug.Log($"Successfully saved data to {path}");
            #endif
        }
        catch(System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"Failed to save data to {path}. \n{exception}");
            #endif
        }
    }



    /// <summary>
    /// ��ȡ����
    /// </summary>
    /// <typeparam name="T">json���л���������</typeparam>
    /// <param name="saveFileName">�浵·����</param>
    /// <returns>���л���</returns>
    public static T LoadFromJson<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);

            return data;
        }
        catch (System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"Failed to load data from {path}. \n{exception}");
            #endif
   
            //���û�ҵ������ļ����򴴽��´浵
            LevelData.FirstSave();

            //�����´浵���ȡ
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);

            return data;

        }
    }



    public static void DeleteSaveFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.Delete(path);
            Debug.Log("delete success");
        }
        catch(System.Exception exception)
        {
            #if UNITY_EDITOR
            Debug.LogError($"Failed to delete {path}. \n{exception}");
            #endif
        }
    }
}
