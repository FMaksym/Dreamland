using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayerGiveResources : MonoBehaviour
{
    [SerializeField] private float _radius;
    [Inject] private Inventory _playerInventory;

    private void FixedUpdate()
    {
        FindGettingResorcesArea();
    }

    private void FindGettingResorcesArea()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (var collider in colliders)
        {
            if (collider.GetComponent<GetResourcesToRecycle>())
            {
                GetResourcesToRecycle gettingResources = collider.GetComponent<GetResourcesToRecycle>();
                gettingResources.GetResources(_playerInventory);
            }
        }
    }
}
