using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayerLandPurchase : MonoBehaviour
{
    [SerializeField] private float _radius;

    [Inject] private PlayerTouchMovement _playerMovement;
    [Inject] private Inventory _playerInventory;
    [Inject] private NavMeshManager _navMesh;

    public delegate void BuyLandEventHandler();
    public static event BuyLandEventHandler BuyLand;

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

            BuyLand?.Invoke();
            DataManager.instance.GameDataChanged();
            StartCoroutine(PurchaseLand());
            StartCoroutine(WaitAndMove(0.5f));
        }
    }

    private IEnumerator PurchaseLand()
    {
        _playerMovement.Moved(false);
        yield return new WaitForSeconds(2f);
        _navMesh.BakeNavMesh();
    }

    IEnumerator WaitAndMove(float time)
    {
        
        yield return new WaitForSeconds(time);
        _playerMovement.Moved(true);
    }
}
