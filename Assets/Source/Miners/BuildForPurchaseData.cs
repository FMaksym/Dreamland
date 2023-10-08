using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildForPurchaseData : MonoBehaviour
{
    public bool isActive;
    public bool isPurchased;
    public bool mainObjectActive;
    public bool priceObjectActive;
    public string mainObjectName;
    public Dictionary<string, int> price;
    public string buildObjectID;
}