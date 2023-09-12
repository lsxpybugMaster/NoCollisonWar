using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelData
{
    #region ����
    public static int levelData = 0;   

    //���л�������
    [System.Serializable] class SaveData
    {
        public int level;
    }
    #endregion

    #region ��������
    //����
    const string PLAYER_DATA_FILE_NAME = "PlayerData.data";
    #endregion

    #region ���ĺ���
    public static void Save()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME,SavingData());
    }

    public static void FirstSave()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData(true));
    }

    public static void Load()
    {
        var saveData = SaveSystem.LoadFromJson<SaveData>(PLAYER_DATA_FILE_NAME);

        LoadingData(saveData);
    }

    //FIXME bulid error here
    //[UnityEditor.MenuItem("SaveDatas/Delete save file")]
    //public static void DeleteSaveFile()
    //{
    //    SaveSystem.DeleteSaveFile(PLAYER_DATA_FILE_NAME);
    //}

    #endregion

    #region ��������

    private static SaveData SavingData(bool firstSave = false)
    {
        var saveData = new SaveData();

        if (!firstSave)
            saveData.level = levelData;
        else
            saveData.level = 0;

        return saveData;
    }

    private static void LoadingData(SaveData saveData)
    {
        levelData = saveData.level;
    }

    public static void dataNow()
    {
        Debug.Log($"data now : {levelData}");
    }
     
    #endregion
}

