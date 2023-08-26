using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private string[] resourceKeys;
    [SerializeField] private TMP_Text[] resourceTexts;
    [Inject] private Inventory inventory;

    private void Start()
    {
        for (int i = 0; i < resourceTexts.Length; i++)
        {
            UpdateResourceText(resourceKeys[i], inventory.GetItem(resourceKeys[i]));
        }
        inventory.OnResourceChanged += UpdateResourceText;
    }

    private void OnDestroy()
    {
        inventory.OnResourceChanged -= UpdateResourceText;
    }

    private void UpdateResourceText(string resourceKey, int resourceCount)
    {
        for (int i = 0; i < resourceKeys.Length; i++)
        {
            if (resourceKeys[i] == resourceKey)
            {
                resourceTexts[i].text = FormatNumber(resourceCount);
                break;
            }
        }
    }

    private string FormatNumber(int num)
    {
        if (num >= 1000000)
            return (num / 1000000).ToString() + "M";
        else if (num >= 1000)
            return (num / 1000).ToString() + "K";
        else
            return num.ToString();
    }
}
