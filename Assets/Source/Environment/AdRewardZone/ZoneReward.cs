using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneReward : MonoBehaviour
{
    [SerializeField] private string _itemName;
    [SerializeField] private int _itemAmount;

    public string ItemName { get => _itemName;}
    public int ItemAmount { get => _itemAmount;}
}
