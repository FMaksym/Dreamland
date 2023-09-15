using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadManager
{
    private string _savePath;

    public LoadManager()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "GameData.json");
    }

    public GameData LoadGame(GameData gameData, List<LandForPurchaseData> territoriesData, List<BuildForPurchaseData> buildingsData)
    {
        //if (File.Exists(_savePath))
        //{
        //    string json = File.ReadAllText(_savePath);
        //    if (!string.IsNullOrEmpty(json))
        //    {
        //        return JsonUtility.FromJson<GameData>(json);
        //    }
        //}

        //File.Create(_savePath).Dispose();
        //return new GameData();

        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            if (!string.IsNullOrEmpty(json))
            {
                return JsonUtility.FromJson<GameData>(json);
            }
        }
        else
        {
            gameData.territoriesData = territoriesData;
            gameData.buildingsData = buildingsData;
        }

        // Если файл не существует или пуст, возвращаем переданный экземпляр GameData
        return gameData;
    }
}
