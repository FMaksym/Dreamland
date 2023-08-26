using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildForPurchaseData : MonoBehaviour
{
    public string name;
    public bool isActive;
    public bool isPurchased;
    public bool mainObjectActive;
    public bool priceObjectActive;
    public GameObject mainObject;
    public BuildPrice priceObject;
    public Dictionary<string, int> price;

    public BuildForPurchaseData(string name, bool isPurchased, bool mainObjectActive, bool priceObjectActive, GameObject mainObject, BuildPrice priceObject)
    {
        this.name = name;
        this.isPurchased = isPurchased;
        this.mainObjectActive = mainObjectActive;
        this.priceObjectActive = priceObjectActive;
        this.mainObject = mainObject;
        this.priceObject = priceObject;
        price = priceObject.Price;
    }
}
