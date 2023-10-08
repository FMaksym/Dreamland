using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Inject] private Inventory _inventory;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadGameData();
    }

    private void LoadGameData()
    {
        List<BuildForPurchaseSaveData> loadBuildingsData = SaveSystem.LoadData<List<BuildForPurchaseSaveData>>("buildings.json", BuildingManager.instance.GetBuildingSaveData());
        List<LandForPurchaseSaveData> loadIslandsData = SaveSystem.LoadData<List<LandForPurchaseSaveData>>("islands.json", IslandManager.instance.GetIslandsSaveData());
        Dictionary<string, int> loadInventoryData = SaveSystem.LoadInventoryData("inventory.json", _inventory.GetItems());
        Debug.Log(loadBuildingsData);
        Debug.Log(loadIslandsData);
        Debug.Log(loadInventoryData);
        BuildingManager.instance.SetBuildingDataFromSaveData(loadBuildingsData);
        IslandManager.instance.SetIslandsDataFromSaveData(loadIslandsData);
        _inventory.SetItems(loadInventoryData);
    }

    private void SaveGameData()
    {
        List<BuildForPurchaseSaveData> saveBuildingsData = BuildingManager.instance.GetBuildingSaveData();
        List<LandForPurchaseSaveData> saveIslandsData = IslandManager.instance.GetIslandsSaveData();
        SaveData("buildings.json", saveBuildingsData);
        SaveData("islands.json", saveIslandsData);
        SaveSystem.SaveInventoryData("inventory.json", _inventory);
    }

    public void SaveData<T>(string fileName, T data) => SaveSystem.SaveData(fileName, data);

    public T LoadData<T>(string fileName,T defaultData) => SaveSystem.LoadData<T>(fileName, defaultData);

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
