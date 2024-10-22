using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LandPrice : MonoBehaviour, ISerializationCallbackReceiver
{
    public bool _isDirty;
    public GameObject LandObject;
    public GameObject PriceObject;
    public GameObject NextLandObject;
    public Dictionary<string, int> Price;

    public LandForPurchaseData landForPurchaseData;

    [SerializeField] private List<TMP_Text> _priceTexts;
    [SerializeField] public List<string> _priceKeys;
    [SerializeField] public List<int> _priceValues;

    private void Start()
    {
        UpdatePrice(landForPurchaseData.Price);
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
        landForPurchaseData.Price = Price;
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
        landForPurchaseData.Price = newPrice;
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
