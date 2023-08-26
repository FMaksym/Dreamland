using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectItem : MonoBehaviour, ICollectable
{
    [SerializeField] private string _nameOfItem;

    public void Collect(Inventory inventory)
    {
        inventory.AddItem(_nameOfItem, 1);
    }
}
