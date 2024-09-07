using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HarvestableResource : MonoBehaviour
{
    [SerializeField] private PlayerChopResources.CollectType _harvestType;

    [SerializeField] private string _nameOfAddItem;
    [SerializeField] private int _addAmount;
    [SerializeField] private float _maxCollectProgress = 100f;
    [SerializeField] private float _collectSpeed = 10f;
    [SerializeField] private float _regenerationTime = 10f;
    [SerializeField] private GameObject _mainObject;
    [SerializeField] private GameObject _floorObject;
    [SerializeField] private GameObject _resourceObject;
    [SerializeField] private List<GameObject> _resourceObjects;

    [SerializeField] private float _progress;
    [SerializeField] private bool _playerInTrigger = false;
    [SerializeField] private bool _isHarvesting = false;
    [SerializeField] private bool _isGrowing = false;
    [SerializeField] private bool _isCollectAllHarvest = true;
    private PlayerChopResources _playerChop;
    
    [Inject] private Inventory _inventory;
    [Inject] private PlayerTouchMovement _player;
    [Inject] private NavMeshManager _navMesh;

    private void Awake()
    {
        _playerChop = _player.GetComponent<PlayerChopResources>();
    }

    private void Update()
    {
        if (_isHarvesting && !_isGrowing)
        {
            _playerChop.CollectResources(_harvestType);

            _progress += _collectSpeed * Time.deltaTime;

            if (_progress >= _maxCollectProgress)
            {
                Harvest();
            }
        }

        if (!_isCollectAllHarvest)
        {
            foreach (GameObject resourceObject in _resourceObjects)
            {
                if (resourceObject.activeSelf)
                {
                    _isCollectAllHarvest = false;
                    return;
                }
                else
                {
                    _isCollectAllHarvest = true;
                }
            }
        }

        if (_isGrowing && !_playerInTrigger && _isCollectAllHarvest)
        {
            // Continue regeneration if player is not in trigger
            RegenerationCoroutine();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerChopResources>())
        {
            _playerInTrigger = true;
            StartHarvesting();
            if (_isGrowing)
            {
                StopCoroutine(RegenerationCoroutine());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerChopResources>())
        {
            _playerChop.StopCollectResources(_harvestType);
            StopHarvesting();
            _playerInTrigger = false;
        }
    }

    private void StartHarvesting()
    {
        if (_isGrowing)
        {
            return;
        }

        _isHarvesting = true;
        _progress = 0f;
        StartCoroutine(RegenerationCoroutine());
    }

    private void StopHarvesting()
    {
        _isHarvesting = false;
        _progress = 0f;
    }

    private void Harvest()
    {
        ActivateResourcesForHarvest();
        _playerChop.StopCollectResources(_harvestType);
        _isGrowing = true;
        //_navMesh.BakeNavMesh();

        StartRegeneration();
    }

    private void ActivateResourcesForHarvest(){
        _mainObject.SetActive(false);
        _floorObject.SetActive(true);
        _resourceObject.SetActive(true);

        foreach (GameObject resourceObject in _resourceObjects)
        {
            resourceObject.SetActive(true);
        }

        _isCollectAllHarvest = false;
    }

    private void StartRegeneration()
    {
        StartCoroutine(RegenerationCoroutine());
    }

    private IEnumerator RegenerationCoroutine()
    {
        while (_isGrowing)
        {
            if (_playerInTrigger && !_isCollectAllHarvest)
            {
                // Pause regeneration if player is in trigger
                yield return new WaitUntil(() => !_playerInTrigger && _isCollectAllHarvest);
            }

            yield return new WaitForSeconds(_regenerationTime);

            _floorObject.SetActive(false);
            _mainObject.SetActive(true);
            _isGrowing = false;

            //    if (!_isGrowing)
            //    {
            //        yield return new WaitForSeconds(1);
            //        _navMesh.BakeNavMesh();
            //    }
        }
    }
}
