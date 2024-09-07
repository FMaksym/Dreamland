using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class GetRecycledResources : MonoBehaviour
{
    public float _speed;
    public float _radius;
    public ResourceRecycle ResourceConvert;
    public List<GameObject> _resourcesToCollect = new List<GameObject>();

    private Dictionary<GameObject, Vector3> _originalPositions = new Dictionary<GameObject, Vector3>();

    [Inject] private PlayerTouchMovement player;

    private void Awake()
    {
        foreach (GameObject resource in ResourceConvert.OutputResourceObjects)
        {
            _originalPositions[resource] = resource.transform.localPosition;
        }
    }

    private void Update()
    {
        FindPlayer();
        if (_resourcesToCollect.Count > 0)
        {
            foreach (GameObject resource in _resourcesToCollect)
            {
                resource.transform.position = Vector3.MoveTowards(resource.transform.position, player.transform.position + new Vector3(0f, 0.5f, 0f), _speed * Time.deltaTime);
            }
            ResourceConvert._currentConversion = 0;
            if (_resourcesToCollect.All(resources => !resources.activeInHierarchy))
            {
                foreach (GameObject resource in _resourcesToCollect)
                {
                    if (_originalPositions.ContainsKey(resource))
                    {
                        resource.transform.localPosition = _originalPositions[resource];
                    }
                }
                _resourcesToCollect.Clear();
            }
        }
    }

    private void FindPlayer()
    {
        bool isPlayerInRange = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (Collider collider in colliders)
        {
            if (collider.transform == player.transform)
            {
                isPlayerInRange = true;
                foreach (GameObject resource in ResourceConvert.OutputResourceObjects)
                {
                    if (resource.activeInHierarchy && Vector3.Distance(transform.position, resource.transform.position) <= _radius)
                    {
                        _resourcesToCollect.Add(resource);
                    }
                }
                ResourceConvert._currentConversion = 0;
            }
        }

        if (!isPlayerInRange && _resourcesToCollect.Count > 0)
        {
            foreach (GameObject resource in _resourcesToCollect)
            {
                if (_originalPositions.ContainsKey(resource))
                {
                    resource.transform.localPosition = _originalPositions[resource];
                }
            }
            _resourcesToCollect.Clear();
        }
        ResourceConvert.IsCollecting = isPlayerInRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
