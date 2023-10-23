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
            DontDestroyOnLoad(gameObject);
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
                isActive = islandData.isActive,
                isPurchased = islandData.isPurchased,
                mainObjectActive = islandData.mainObjectActive,
                priceObjectActive = islandData.priceObjectActive,
                mainObjectName = islandData.mainObjectName,
                price = islandData.price,
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

            landData.isActive = saveData.isActive;
            landData.isPurchased = saveData.isPurchased;
            landData.mainObjectActive = saveData.mainObjectActive;
            landData.priceObjectActive = saveData.priceObjectActive;
            landData.mainObjectName = saveData.mainObjectName;
            landData.price = saveData.price;
            landData.landObjectID = saveData.landObjectID;

            landData.gameObject.SetActive(landData.isActive);

            landObject.landObject.gameObject.SetActive(landData.mainObjectActive);
            landObject.priceObject.gameObject.SetActive(landData.priceObjectActive);

            landObject.priceObject.Price = landData.price;
        }
    }
}
