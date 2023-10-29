using UnityEngine;
using System.Collections.Generic;
using Zenject;
using System.IO;

public class DataManager : MonoBehaviour
{
    public DataPanel dataPanel;

    public static DataManager instance;

    [Inject] private Inventory _inventory;
    [Inject] private NavMeshManager _navMesh;

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
    }

    private void Start()
    {
        LoadGameData();
        _navMesh.BakeNavMesh();
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

        SaveGameData();
    }

    public void LoadData()
    {
        List<LandForPurchaseSaveData> loadIslandsData = SaveSystem.LoadData<List<LandForPurchaseSaveData>>("islands.json", IslandManager.instance.GetIslandsSaveData());
        dataPanel._dataPathText.text = loadIslandsData.ToString();
    }

    private void SaveGameData()
    {
        List<BuildForPurchaseSaveData> saveBuildingsData = BuildingManager.instance.GetBuildingSaveData();
        List<LandForPurchaseSaveData> saveIslandsData = IslandManager.instance.GetIslandsSaveData();
        SaveData("buildings.json", saveBuildingsData);
        SaveData("islands.json", saveIslandsData);
        SaveSystem.SaveInventoryData("inventory.json", _inventory);
    }

    public void Save()
    {
        //List<BuildForPurchaseSaveData> saveBuildingsData = BuildingManager.instance.GetBuildingSaveData();
        //string jsonData = JsonConvert.SerializeObject(saveBuildingsData, Formatting.Indented);
        //dataPanel._dataPathText.text = jsonData.ToString();

        if (File.Exists(Application.persistentDataPath + "/buildings.json"))
        {
            dataPanel._dataPathText.text = "File here";
        }
        else
        {
            dataPanel._dataPathText.text = "File not here";
            //File.Create(Application.persistentDataPath + "/buildings.json");
        }

        SaveGameData();
    }

    public void SaveData<T>(string fileName, T data) => SaveSystem.SaveData(fileName, data);

    public T LoadData<T>(string fileName,T defaultData) => SaveSystem.LoadData<T>(fileName, defaultData);

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
