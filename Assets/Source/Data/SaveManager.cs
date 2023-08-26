using System.IO;
using UnityEngine;

public class SaveManager
{
    private string _savePath;

    public SaveManager()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "GameData.json");
    }

    public void SaveGame(GameData gameData)
    {
        string json = JsonUtility.ToJson(gameData);
        Debug.Log("JSON data: " + json);
        File.WriteAllText(_savePath, json);
    }
}
