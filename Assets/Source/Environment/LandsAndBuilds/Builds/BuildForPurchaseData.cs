using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildForPurchaseData : MonoBehaviour, IPurchasable
{
    public bool isActive;
    public bool isPurchased;
    public bool mainObjectActive;
    public bool priceObjectActive;
    public string mainObjectName;
    public Dictionary<string, int> price;
    public string buildObjectID;

    public bool IsActive { get { return isActive; } set { isActive = value; } }
    public bool IsPurchased { get { return isPurchased; } set { isPurchased = value; } }
    public bool MainObjectActive { get { return mainObjectActive; } set { mainObjectActive = value; } }
    public bool PriceObjectActive { get { return priceObjectActive; } set { priceObjectActive = value; } }
    public string MainObjectName { get { return mainObjectName; } set { mainObjectName = value; } }
    public Dictionary<string, int> Price { get { return price; } set { price = value; } }

    public bool ObjectIsActive()
    {
        return priceObjectActive;
    }
}