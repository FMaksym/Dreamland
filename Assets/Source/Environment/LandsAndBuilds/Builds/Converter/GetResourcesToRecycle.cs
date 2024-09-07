using UnityEngine;
using Zenject;

public class GetResourcesToRecycle : MonoBehaviour
{
    [SerializeField] private ResourceRecycle resourceConvert;
    [SerializeField] private float _radius;

    [Inject] private Inventory _playerInventory;

    private void FixedUpdate()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (var collider in colliders)
        {
            if (collider.GetComponent<PlayerTouchMovement>())
            {
                GetResources(_playerInventory);
            }
        }
    }

    public void GetResources(Inventory inventory)
    {
        if (_playerInventory.ContainsKey(resourceConvert.InputResourceName))
        {
            int neededCount = resourceConvert.MaxInputResource - resourceConvert.GetActiveInputCount();
            int playerResource = inventory.GetItem(resourceConvert.InputResourceName);
            int amountToSpend = Mathf.Min(playerResource, neededCount);
            inventory.RemoveItem(resourceConvert.InputResourceName, amountToSpend);
            AddingResources(amountToSpend);
            DataManager.instance.GameDataChanged();
        }
    }

    private void AddingResources(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject inputObject = resourceConvert.InputResourceObjects[resourceConvert.GetActiveInputCount()];
            inputObject.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
