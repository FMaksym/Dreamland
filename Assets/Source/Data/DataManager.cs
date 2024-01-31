using UnityEngine;
using System.Collections.Generic;
using Zenject;
using System.IO;
using System.Collections;

public class DataManager : MonoBehaviour
{
    public int _firstStart;

    public static DataManager instance;

    [Inject] private Inventory _inventory;
    [Inject] private NavMeshManager _navMesh;

    public delegate void GameDataChangedEventHandler();
    public static event GameDataChangedEventHandler OnGameDataChanged;

    private void OnEnable()
    {
        OnGameDataChanged += HandleGameDataChanged;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _firstStart = PlayerPrefs.GetInt("FirstStart", 1);
        if (_firstStart == 1)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    private void Start()
    {
        LoadGameData();
        StartCoroutine(WaitAndBake(1.5f));
        _navMesh.BakeNavMesh();
    }

    private void LoadGameData()
    {
        List<BuildForPurchaseSaveData> loadBuildingsData = SaveSystem.LoadData<List<BuildForPurchaseSaveData>>("buildings.json", BuildingManager.instance.GetBuildingSaveData());
        List<LandForPurchaseSaveData> loadIslandsData = SaveSystem.LoadData<List<LandForPurchaseSaveData>>("islands.json", IslandManager.instance.GetIslandsSaveData());
        Dictionary<string, int> loadInventoryData = SaveSystem.LoadInventoryData("inventory.json", _inventory.GetItems());
        
        BuildingManager.instance.SetBuildingDataFromSaveData(loadBuildingsData);
        IslandManager.instance.SetIslandsDataFromSaveData(loadIslandsData);
        _inventory.SetItems(loadInventoryData);

        PlayerPrefs.SetInt("FirstStart", 0);
        SaveGameData();
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

    private void HandleGameDataChanged()
    {
        StartCoroutine(Wait());
        SaveGameData();
    }

    public void GameDataChanged()
    {
        OnGameDataChanged?.Invoke();
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }


    //private void OnApplicationQuit()
    //{
    //    SaveGameData();
    //}

    private void OnDestroy()
    {
        OnGameDataChanged -= HandleGameDataChanged;
    }

    private IEnumerator WaitAndBake(float time)
    {
        yield return new WaitForSeconds(time);
        _navMesh.BakeNavMesh();
    }

    public void ClearAllData()
    {
        SaveSystem.DeleteJsonFile("buildings.json");
        SaveSystem.DeleteJsonFile("islands.json");
        SaveSystem.DeleteJsonFile("inventory.json");

        PlayerPrefs.DeleteAll();
    }
}
