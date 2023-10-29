using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;
    public List<BuildForPurchaseData> buildings;

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

    public List<BuildForPurchaseSaveData> GetBuildingSaveData()
    {
        List<BuildForPurchaseSaveData> saveDataList = new List<BuildForPurchaseSaveData>();

        foreach (BuildForPurchaseData buildData in buildings)
        {
            BuildForPurchaseSaveData saveData = new BuildForPurchaseSaveData
            {
                isActive = buildData.isActive,
                isPurchased = buildData.isPurchased,
                mainObjectActive = buildData.mainObjectActive,
                priceObjectActive = buildData.priceObjectActive,
                mainObjectName = buildData.mainObjectName,
                price = buildData.price,
                buildObjectID = buildData.buildObjectID
            };
            saveDataList.Add(saveData);
        }
        return saveDataList;
    }

    public void SetBuildingDataFromSaveData(List<BuildForPurchaseSaveData> saveDataList)
    {
        int count = Mathf.Min(buildings.Count, saveDataList.Count);

        for (int i = 0; i < count; i++)
        {
            BuildForPurchaseData buildData = buildings[i];
            BuildForPurchaseSaveData saveData = saveDataList[i];
            BuildObject buildObject = buildData.GetComponent<BuildObject>();

            buildData.isActive = saveData.isActive;
            buildData.isPurchased = saveData.isPurchased;
            buildData.mainObjectActive = saveData.mainObjectActive;
            buildData.priceObjectActive = saveData.priceObjectActive;
            buildData.mainObjectName = saveData.mainObjectName;
            buildData.price = saveData.price;
            buildData.buildObjectID = saveData.buildObjectID;

            buildData.gameObject.SetActive(buildData.isActive);

            buildObject.buildObject.gameObject.SetActive(buildData.mainObjectActive);
            buildObject.priceObject.gameObject.SetActive(buildData.priceObjectActive);

            buildObject.priceObject.Price = buildData.price;
        }
    }
}
