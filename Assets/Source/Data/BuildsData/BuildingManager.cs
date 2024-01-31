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
                isActive = buildData.IsActive,
                isPurchased = buildData.IsPurchased,
                mainObjectActive = buildData.MainObjectActive,
                priceObjectActive = buildData.PriceObjectActive,
                mainObjectName = buildData.MainObjectName,
                price = buildData.Price,
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

            buildData.IsActive = saveData.isActive;
            buildData.IsPurchased = saveData.isPurchased;
            buildData.MainObjectActive = saveData.mainObjectActive;
            buildData.PriceObjectActive = saveData.priceObjectActive;
            buildData.MainObjectName = saveData.mainObjectName;
            buildData.Price = saveData.price;
            buildData.buildObjectID = saveData.buildObjectID;

            buildData.gameObject.SetActive(buildData.IsActive);

            buildObject.buildObject.gameObject.SetActive(buildData.MainObjectActive);
            buildObject.priceObject.gameObject.SetActive(buildData.PriceObjectActive);

            buildObject.priceObject.Price = buildData.Price;
        }
    }
}
