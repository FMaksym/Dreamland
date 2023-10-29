using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cinemachine;
using Zenject;

public class PlayerLandPurchase : MonoBehaviour
{
    [SerializeField] private float _radius;

    [Inject] private PlayerTouchMovement _playerMovement;
    [Inject] private Inventory _playerInventory;
    [Inject] private NavMeshManager _navMesh;

    private void FixedUpdate()
    {
        FindLandPrice();
    }

    private void FindLandPrice()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (var collider in colliders)
        {
            LandPrice landPrice = collider.GetComponent<LandPrice>();
            if (landPrice != null)
            {
                SpendResources(landPrice);
            }
        }
    }

    private void SpendResources(LandPrice landPrice)
    {
        Dictionary<string, int> newPrice = new Dictionary<string, int>(landPrice.Price);
        foreach (KeyValuePair<string, int> resource in landPrice.Price)
        {
            int playerResource = 0;
            if (_playerInventory.ContainsKey(resource.Key))
            {
                playerResource = _playerInventory.GetItem(resource.Key);
                int amountToSpend = Mathf.Min(playerResource, resource.Value);
                _playerInventory.RemoveItem(resource.Key, amountToSpend);
                newPrice[resource.Key] -= amountToSpend;
            }
            DataManager.instance.GameDataChanged();
        }

        landPrice.Price = newPrice;
        landPrice.UpdatePrice(newPrice);

        if (landPrice.Price.Values.OfType<int>().All(value => value == 0))
        {
            landPrice.LandObject.SetActive(true);
            landPrice.PriceObject.SetActive(false);
            if (landPrice.NextLandObject != null)
            {
                landPrice.NextLandObject.SetActive(true);
                landPrice.NextLandObject.GetComponent<LandForPurchaseData>().isActive = true;
                landPrice.landForPurchaseData.isPurchased = true;
                landPrice.landForPurchaseData.mainObjectActive = true;
                landPrice.landForPurchaseData.priceObjectActive = false;
            }

            DataManager.instance.GameDataChanged();
            StartCoroutine(PurchaseLand());
        }
    }

    private IEnumerator PurchaseLand()
    {
        _playerMovement.Moved(false);
        _navMesh.BakeNavMesh();

        yield return new WaitForSeconds(2f);

        _playerMovement.Moved(true);

    }
}
