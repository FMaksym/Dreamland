using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> _items = new();
    public event Action<string, int> OnResourceChanged;

    public void AddItem(string item, int amount)
    {
        if (_items.ContainsKey(item))
            _items[item] += amount;
        else
            _items[item] = amount;
        OnResourceChanged?.Invoke(item, _items[item]);
    }

    public void RemoveItem(string item, int amount)
    {
        if (_items.ContainsKey(item))
            _items[item] -= amount;
        OnResourceChanged?.Invoke(item, _items[item]);
    }

    public int GetItem(string item)
    {
        if (_items.ContainsKey(item))
            return _items[item];
        else
            return 0;
    }

    public bool ContainsKey(string key)
    {
        return _items.ContainsKey(key);
    }

    public Dictionary<string, int> GetItems()
    {
        return _items;
    }
}
