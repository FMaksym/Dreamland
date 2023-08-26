using System.IO;
using UnityEngine;

public class LoadManager
{
    private string _savePath;

    public LoadManager()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "GameData.json");
    }

    public GameData LoadGame()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            File.Create(_savePath).Dispose();
            return new GameData();
        }
    }
}
