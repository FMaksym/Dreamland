using System.Collections.Generic;
using UnityEngine;

public class IslandManager : MonoBehaviour
{
    public static IslandManager instance;
    public List<LandForPurchaseData> islands;

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

    public List<LandForPurchaseSaveData> GetIslandsSaveData()
    {
        List<LandForPurchaseSaveData> saveDataList = new List<LandForPurchaseSaveData>();

        foreach (LandForPurchaseData islandData in islands)
        {
            LandForPurchaseSaveData saveData = new LandForPurchaseSaveData
            {
                isActive = islandData.IsActive,
                isPurchased = islandData.IsPurchased,
                mainObjectActive = islandData.MainObjectActive,
                priceObjectActive = islandData.PriceObjectActive,
                mainObjectName = islandData.MainObjectName,
                price = islandData.Price,
                landObjectID = islandData.landObjectID
            };
            saveDataList.Add(saveData);
        }
        return saveDataList;
    }

    public void SetIslandsDataFromSaveData(List<LandForPurchaseSaveData> saveDataList)
    {
        int count = Mathf.Min(islands.Count, saveDataList.Count);

        for (int i = 0; i < count; i++)
        {
            LandForPurchaseData landData = islands[i];
            LandForPurchaseSaveData saveData = saveDataList[i];
            LandObject landObject = landData.GetComponent<LandObject>();

            landData.IsActive = saveData.isActive;
            landData.IsPurchased = saveData.isPurchased;
            landData.MainObjectActive = saveData.mainObjectActive;
            landData.PriceObjectActive = saveData.priceObjectActive;
            landData.MainObjectName = saveData.mainObjectName;
            landData.Price = saveData.price;
            landData.landObjectID = saveData.landObjectID;

            landData.gameObject.SetActive(landData.IsActive);

            landObject.landObject.gameObject.SetActive(landData.MainObjectActive);
            landObject.priceObject.gameObject.SetActive(landData.PriceObjectActive);

            landObject.priceObject.Price = landData.Price;
        }
    }
}
