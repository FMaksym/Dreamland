using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LandForPurchaseData : MonoBehaviour
{
    public string name;
    public bool isActive;
    public bool isPurchased;
    public bool mainObjectActive;
    public bool priceObjectActive;
    public GameObject landObject;
    public LandPrice priceObject;
    public Dictionary<string, int> price;

    public LandForPurchaseData(string name, bool isPurchased, bool mainObjectActive, bool priceObjectActive, GameObject mainObject, LandPrice priceObject)
    {
        this.name = name;
        this.isPurchased = isPurchased;
        this.mainObjectActive = mainObjectActive;
        this.priceObjectActive = priceObjectActive;
        this.landObject = mainObject;
        this.priceObject = priceObject;
        price = priceObject.Price;
    }
}