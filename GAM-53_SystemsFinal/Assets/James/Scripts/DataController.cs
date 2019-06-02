using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    #region Variables
    private string gameDataFileName = "data.json";
    private PokemawnDexData[] allPokemawnDexData;
    #endregion

    #region Methods
    void Start()
    {
		
	}
	
	void Update()
    {
		
	}

    private void LoadGameData()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            PokemawnDexData loadedData = JsonUtility.FromJson<PokemawnDexData>(dataAsJson);

            // Retrieve the allRoundData property of loadedData
            allPokemawnDexData = loadedData.allPokemawn;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }
    #endregion
}
