using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

public static class SaveSystem
{
    public static void SaveData<T>(string fileName, T data)
    {
        string jsonData = JsonConvert.SerializeObject(data);
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, jsonData);
    }

    public static T LoadData<T>(string fileName, T defaultData = default)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(jsonData) && jsonData != "{}" && jsonData != " ")
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
        return defaultData;
    }

    public static void SaveInventoryData(string fileName, Inventory inventory)
    {
        InventorySaveData saveData = new InventorySaveData();
        saveData.items = new List<InventoryItemSaveData>();

        foreach (var item in inventory.GetItems())
        {
            InventoryItemSaveData itemSaveData = new InventoryItemSaveData()
            {
                itemName = item.Key,
                amount = item.Value
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
