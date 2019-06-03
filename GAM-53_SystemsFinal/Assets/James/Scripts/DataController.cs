using System.IO;
using UnityEngine;

public static class DataController
{
    #region Methods
    public static void SaveData<T>(string fileName, T objectType)
    {
        string fileSave = JsonUtility.ToJson(objectType);
        File.WriteAllText("Assets/Data/" + fileName + ".json", fileSave);
    }

    public static void LoadGameData<T>(string fileName, T objectType)
    {
        string savedData = null;

        if (File.Exists("Assets/Data/" + fileName + ".json"))
        {
            savedData = File.ReadAllText("Assets/Data/" + fileName + ".json");
            JsonUtility.FromJsonOverwrite(savedData, objectType);
        }
        else
        {
            SaveData(fileName, objectType);
        }
    }
    #endregion
}
