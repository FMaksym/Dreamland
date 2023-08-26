using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ResourceCollector : MonoBehaviour
{
    public float collectionRadius = 5f;
    public float collectionSpeed = 5f;
    public ResourceMine resourceMine;

    public List<GameObject> _resourcesToCollect = new List<GameObject>();

    private Dictionary<GameObject, Vector3> _originalPositions = new Dictionary<GameObject, Vector3>();

    [Inject] private PlayerTouchMovement player;

    private void Awake()
    {
        foreach (GameObject resource in resourceMine.ResourceObjects)
        {
            _originalPositions[resource] = resource.transform.position;
        }
    }

    private void Update()
    {
        FindPlayer();
        if (_resourcesToCollect.Count > 0)
        {
            foreach (GameObject resource in _resourcesToCollect)
            {
                resource.transform.position = Vector3.MoveTowards(resource.transform.position, player.transform.position + new Vector3(0f, 0.5f, 0f), collectionSpeed * Time.deltaTime);
            }
            resourceMine._currentProduction = 0;

            if (_resourcesToCollect.All(r => !r.activeInHierarchy))
            {
                foreach (GameObject resource in _resourcesToCollect)
                {
                    if (_originalPositions.ContainsKey(resource))
                    {
                        resource.transform.position = _originalPositions[resource];
                    }
                }
                _resourcesToCollect.Clear();
            }
        }
    }

    private void FindPlayer()
    {
        bool isPlayerInRange = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, collectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.transform == player.transform)
            {
                isPlayerInRange = true;
                foreach (GameObject resource in resourceMine.ResourceObjects)
                {
                    if (resource.activeInHierarchy && Vector3.Distance(transform.position, resource.transform.position) <= collectionRadius)
                    {
                        _resourcesToCollect.Add(resource);
                    }
                }
                resourceMine._currentProduction = 0;
            }
        }

        if (!isPlayerInRange && _resourcesToCollect.Count > 0)
        {
            foreach (GameObject resource in _resourcesToCollect)
            {
                if (_originalPositions.ContainsKey(resource))
                {
                    resource.transform.position = _originalPositions[resource];
                }
            }

            _resourcesToCollect.Clear();
        }

        resourceMine.IsCollecting = isPlayerInRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, collectionRadius);
    }
}
