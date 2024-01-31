using TMPro;
using UnityEngine;
using Zenject;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private string[] resourceKeys;
    [SerializeField] private TMP_Text[] resourceTexts;
    [Inject] private Inventory inventory;

    private void OnEnable()
    {
        inventory.OnResourceChanged += UpdateResourceText;
    }

    private void Start()
    {
        for (int i = 0; i < resourceTexts.Length; i++)
        {
            UpdateResourceText(resourceKeys[i], inventory.GetItem(resourceKeys[i]));
        }
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
            return ((float)num / 1000000).ToString() + "M";
        else if (num >= 1000)
            return ((float)num / 1000).ToString() + "K";
        else
            return num.ToString();
    }

    private void OnDisable()
    {
        inventory.OnResourceChanged -= UpdateResourceText;
    }
}
