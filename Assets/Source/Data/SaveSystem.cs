using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

public static class SaveSystem
{
    public static void SaveData<T>(string fileName, T data)
    {
        string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
        #if UNITY_EDITOR
            string path = Path.Combine(Application.persistentDataPath, fileName);
        #elif UNITY_ANDROID
        string path = Path.Combine(Application.persistentDataPath + "/files/", fileName);
        #endif
        File.WriteAllText(path, jsonData);
    }

    public static T LoadData<T>(string fileName, T defaultData = default)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(jsonData) && jsonData != "{}")
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(jsonData);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error deserializing JSON for file {fileName}: {e}");
                }
            }
        }
        else
        {
            Debug.LogWarning("Save file not found. Creating new file...");
            File.Create(path).Close();
        }

        return defaultData;
    }

    public static void SaveInventoryData(string fileName, Inventory inventory)
    {
        InventorySaveData saveData = new InventorySaveData();
        saveData.items = new List<InventoryItemSaveData>();

        foreach (var kvp in inventory.GetItems())
        {
            InventoryItemSaveData itemSaveData = new InventoryItemSaveData()
            {
                itemName = kvp.Key,
                amount = kvp.Value
            };

            saveData.items.Add(itemSaveData);
        }

        SaveData(fileName, saveData);
    }

    public static Dictionary<string, int> LoadInventoryData(string fileName, Dictionary<string, int> defaultData)
    {
        InventorySaveData saveData = LoadData<InventorySaveData>(fileName);

        if (saveData != null)
        {
            Dictionary<string, int> loadedData = new Dictionary<string, int>();

            foreach (var itemSaveData in saveData.items)
            {
                loadedData[itemSaveData.itemName] = itemSaveData.amount;
            }

            return loadedData;
        }
        else
        {
            return defaultData;
        }
    }
}
