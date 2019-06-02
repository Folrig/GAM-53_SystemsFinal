using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    #region Methods
    public static void SaveData<T>(string fileName, T objectType)
    {
        string fileSave = JsonUtility.ToJson(objectType);
        File.WriteAllText("Data/" + fileName + ".json", fileSave);
    }

    private void LoadGameData<T>(string fileName, T objectType)
    {
        string savedData = null;

        if (File.Exists("Data/" + fileName + ".json"))
        {
            savedData = File.ReadAllText("Data/" + fileName + ".json");
            JsonUtility.FromJsonOverwrite(savedData, objectType);
        }
        else
        {
            SaveData(fileName, objectType);
        }
    }
    #endregion
}
