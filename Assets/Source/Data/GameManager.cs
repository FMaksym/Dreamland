using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using Zenject;

public class GameManager : MonoBehaviour
{
    public List<LandForPurchaseData> territoriesData;
    public List<BuildForPurchaseData> buildingsData;

    public Dictionary<string, LandForPurchaseData> territories;
    public Dictionary<string, BuildForPurchaseData> buildings;

    private SaveManager _saveManager;
    private LoadManager _loadManager;
    public GameData _gameData;

    [Inject] private Inventory inventory;

    void Awake()
    {
        InitializeData();
    }

    private void Start()
    {
        RequestToFile();
    }

    private void RequestToFile()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
        }
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
    }

    private void InitializeData()
    {
        _saveManager = new SaveManager();
        _loadManager = new LoadManager();
        _gameData = _loadManager.LoadGame();


        // Находим все объекты с компонентом LandForPurchaseData на сцене

        foreach (LandForPurchaseData territoryData in _gameData.territoriesData)
        {
            bool isActive = territoryData.isActive;
            string territoryName = territoryData.name;
            bool territoryIsPurchased = territoryData.isPurchased;
            bool territoryMainObjectActive = territoryData.mainObjectActive;
            bool territoryPriceObjectActive = territoryData.priceObjectActive;
            GameObject territoryMainObject = territoryData.landObject;
            LandPrice territoryPriceObject = territoryData.priceObject;
            Dictionary<string, int> territoryPrice = territoryData.price;
        }

        foreach (BuildForPurchaseData buildingData in _gameData.buildingsData)
        {
            bool isActive = buildingData.isActive;
            string buildingName = buildingData.name;
            bool buildingIsPurchased = buildingData.isPurchased;
            bool buildingMainObjectActive = buildingData.mainObjectActive;
            bool buildingPriceObjectActive = buildingData.priceObjectActive;
            GameObject buildMainObject = buildingData.mainObject;
            BuildPrice buildPriceObject = buildingData.priceObject;
            Dictionary<string, int> buildingPrice = buildingData.price;
        }

        foreach (KeyValuePair<string, int> item in _gameData.inventory)
        {
            inventory.AddItem(item.Key, item.Value);
        }

        WriteNames();
    }

    private void WriteNames()
    {
        territories = new Dictionary<string, LandForPurchaseData>();
        buildings = new Dictionary<string, BuildForPurchaseData>();

        foreach (LandForPurchaseData territory in FindObjectsOfType<LandForPurchaseData>())
        {
            territories.Add(territory.name, territory);
        }
        
        foreach (BuildForPurchaseData building in FindObjectsOfType<BuildForPurchaseData>())
        {
            buildings.Add(building.name, building);
        }
    }

    public LandForPurchaseData GetTerritoryByName(string name)
    {
        if (territories.ContainsKey(name))
        {
            return territories[name];
        }
        else
        {
            return null;
        }
    }

    public BuildForPurchaseData GetBuildingByName(string name)
    {
        if (buildings.ContainsKey(name))
        {
            return buildings[name];
        }
        else
        {
            return null;
        }
    }

    void OnApplicationQuit()
    {
        foreach (LandForPurchaseData territoryData in _gameData.territoriesData)
        {
            string territoryName = territoryData.name;
            LandForPurchaseData territory = GetTerritoryByName(territoryName);
            if (territory != null)
            {
                territoryData.isPurchased = territory.isPurchased;
                territoryData.mainObjectActive = territory.landObject.activeSelf;
                territoryData.priceObjectActive = territory.priceObject.gameObject.activeSelf;
                territoryData.price = territory.priceObject.GetPrice();
            }
        }

        foreach (BuildForPurchaseData buildingData in _gameData.buildingsData)
        {
            string buildingName = buildingData.name;
            BuildForPurchaseData building = GetBuildingByName(buildingName);
            if (building != null)
            {
                buildingData.isPurchased = building.isPurchased;
                buildingData.mainObjectActive = building.mainObject.activeSelf;
                buildingData.priceObjectActive = building.priceObject.gameObject.activeSelf;
                buildingData.price = building.priceObject.GetPrice();
            }
        }

        foreach (KeyValuePair<string, int> item in inventory.GetItems())
        {
            _gameData.inventory[item.Key] = item.Value;
        }

        Debug.Log("Territories data count: " + _gameData.territoriesData.Count);
        Debug.Log("Buildings data count: " + _gameData.buildingsData.Count);

        _saveManager.SaveGame(_gameData);
    }
}
