using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceMine : MonoBehaviour, IResourceFactory
{
    public string _resourceName;
    public int _productionRate;
    public int _maxProduction;
    public int _currentProduction;
    public bool IsCollecting;

    [SerializeField] private List<Transform> _resourcesSpawnPoints;
    [SerializeField] private GameObject _resourcePrefab;
    [SerializeField] private Transform _resourcesList;
    

    private float _timeSinceLastProduction;
    public List<GameObject> _itemObjects = new();

    public string ResourceName => _resourceName;
    public int ProductionRate => _productionRate;
    public int MaxProduction => _maxProduction;
    public List<Transform> SpawnPoints => _resourcesSpawnPoints;
    public List<GameObject> ResourceObjects => _itemObjects;

    private void Update()
    {
        if (!IsCollecting)
        {
            _timeSinceLastProduction += Time.deltaTime;
            if (_timeSinceLastProduction >= ProductionRate && _currentProduction < MaxProduction)
            {
                ProduceResource();
                _timeSinceLastProduction = 0f;
            }
        }  
    }

    public void ProduceResource()
    {
        GameObject resourceObject = ResourceObjects[GetActiveResourceCount()];
        resourceObject.SetActive(true);
        _currentProduction++;
    }

    private int GetActiveResourceCount()
    {
        return ResourceObjects.Count(o => o.activeInHierarchy);
    }
}
