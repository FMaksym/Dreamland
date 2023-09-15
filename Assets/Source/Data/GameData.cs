using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<LandForPurchaseData> territoriesData;
    public List<BuildForPurchaseData> buildingsData;
    public Dictionary<string, int> inventory;

    public GameData()
    {
        if (territoriesData == null)
            territoriesData = new List<LandForPurchaseData>();
        if (buildingsData == null)
            buildingsData = new List<BuildForPurchaseData>();
        if (inventory == null)
            inventory = new Dictionary<string, int>();

        //territoriesData = new List<LandForPurchaseData>();
        //buildingsData = new List<BuildForPurchaseData>();
        //inventory = new Dictionary<string, int>();
    }
}
