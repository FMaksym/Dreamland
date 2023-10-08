using System.Collections.Generic;

[System.Serializable]
public class BuildForPurchaseSaveData
{
    public bool isActive;
    public bool isPurchased;
    public bool mainObjectActive;
    public bool priceObjectActive;
    public string mainObjectName;
    public Dictionary<string, int> price;
    public string buildObjectID;
}
