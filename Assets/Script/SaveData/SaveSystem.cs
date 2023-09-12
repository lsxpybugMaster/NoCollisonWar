using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem 
{
    /// <summary>
    /// 存储数据
    /// </summary>
    /// <param name="saveFileName">存档路径</param>
    /// <param name="data">存储的序列化数据（推荐序列化的类）</param>
    public static void SaveByJson(string saveFileName,object data)
    {
        //要求 object data 可序列化 
        var json = JsonUtility.ToJson(data);
        //使用Application.persistentDataPath，使得存档路径可依据平台自适应
        var path = Path.Combine(Application.persistentDataPath,saveFileName);

        try
        {
            //此函数会覆盖写入
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
    /// 读取数据
    /// </summary>
    /// <typeparam name="T">json序列化数据类型</typeparam>
    /// <param name="saveFileName">存档路径名</param>
    /// <returns>序列化类</returns>
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
   
            //如果没找到数据文件，则创建新存档
            LevelData.FirstSave();

            //创建新存档后读取
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
