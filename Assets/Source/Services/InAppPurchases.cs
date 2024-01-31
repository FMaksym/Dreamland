using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

public class InAppPurchases : MonoBehaviour
{
    [Inject] private Inventory _inventory;

    public void OnPurchaseComplated(Product product)
    {
        BuyResource(product);
    }

    private void BuyResource(Product product)
    {
        _inventory.AddItem(product.definition.payout.data, (int)product.definition.payout.quantity);
        DataManager.instance.GameDataChanged();
    }
}
