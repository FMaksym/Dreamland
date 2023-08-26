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
        territoriesData = new List<LandForPurchaseData>();
        buildingsData = new List<BuildForPurchaseData>();
        inventory = new Dictionary<string, int>();
    }
}
