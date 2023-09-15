using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildPrice : MonoBehaviour, ISerializationCallbackReceiver
{
    public bool _isDirty;
    public GameObject BildObject;
    public GameObject PriceObject;
    public GameObject NextBuildObject;
    public Dictionary<string, int> Price;

    public BuildForPurchaseData buildForPurchaseData;

    [SerializeField] private List<TMP_Text> _priceTexts;
    [SerializeField] public List<string> _priceKeys;
    [SerializeField] public List<int> _priceValues;

    private void Start()
    {
        UpdatePrice(Price);
    }

    public void OnBeforeSerialize()
    {
        if (_isDirty)
        {
            _priceKeys = new List<string>(Price.Keys);
            _priceValues = new List<int>(Price.Values);
            _isDirty = false;
        }
    }

    public void OnAfterDeserialize()
    {
        Price = new Dictionary<string, int>();
        for (int i = 0; i < Mathf.Min(_priceKeys.Count, _priceValues.Count); i++)
        {
            Price.Add(_priceKeys[i], _priceValues[i]);
        }
        _isDirty = true;
    }

    public void UpdatePrice(Dictionary<string, int> newPrice)
    {
        for (int i = 0; i < _priceTexts.Count; i++)
        {
            if (i < _priceKeys.Count)
            {
                string key = _priceKeys[i];
                int value = newPrice[key];
                _priceTexts[i].text = value.ToString();
            }
        }
        _isDirty = true;
    }

    public void AddPrice(string key, int value)
    {
        _priceKeys.Add(key);
        _priceValues.Add(value);
    }

    public void RemovePrice(int index)
    {
        if (index >= 0 && index < _priceKeys.Count)
        {
            _priceKeys.RemoveAt(index);
            _priceValues.RemoveAt(index);
        }
    }

    public void SetPrice(Dictionary<string, int> newPrice)
    {
        Price = newPrice;
        UpdatePrice(Price);
    }

    public Dictionary<string, int> GetPrice()
    {
        return Price;
    }
}
