using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ArrowTargetManager : MonoBehaviour
{
    [SerializeField] private ArrowIndicator _buildingArrowIndicator;
    [SerializeField] private ArrowIndicator _territoryArrowIndicator;

    public int _currentBuildingIndex = 0;
    public int _currentTerritoryIndex = 0;

    public BuildingManager _buildingManager;
    public IslandManager _islandManager;

    private void OnEnable()
    {
        // Подписываемся на события покупки
        PlayerBildPurchase.BuyBuild += OnBuildingPurchased;
        PlayerLandPurchase.BuyLand += OnTerritoryPurchased;
    }

    private void Start()
    {
        Initialize();
        //UpdateNextTarget();
        WaitAndGetTarget();
    }

    private void Initialize()
    {
        _buildingManager = BuildingManager.instance;
        _islandManager = IslandManager.instance;
    }

    private void UpdateNextTarget()
    {
        // Обновляем цель для стрелки зданий
        while (_currentBuildingIndex < _buildingManager.buildings.Count && _buildingManager.buildings[_currentBuildingIndex].IsPurchased)
        {
            _currentBuildingIndex++;
        }

        // Обновляем цель для стрелки территорий
        while (_currentTerritoryIndex < _islandManager.islands.Count && _islandManager.islands[_currentTerritoryIndex].IsPurchased)
        {
            _currentTerritoryIndex++;
        }

        // Устанавливаем новую цель для стрелки зданий
        if (_currentBuildingIndex < _buildingManager.buildings.Count)
        {
            _buildingArrowIndicator.SetTarget(_buildingManager.buildings[_currentBuildingIndex].transform);
        }
        else
        {
            _buildingArrowIndicator.Hide();
        }

        // Устанавливаем новую цель для стрелки территорий
        if (_currentTerritoryIndex < _islandManager.islands.Count)
        {
            _territoryArrowIndicator.SetTarget(_islandManager.islands[_currentTerritoryIndex].transform);
        }
        else
        {
            _territoryArrowIndicator.Hide();
        }
    }

    private async Task WaitAndGetTarget()
    {
        await Task.Delay(2000);
        UpdateNextTarget();
    }

    private void OnBuildingPurchased()
    {
        WaitAndGetTarget();
    }

    private void OnTerritoryPurchased()
    {
        WaitAndGetTarget();
    }

    private void OnDisable()
    {
        // Отписываемся от событий покупки
        PlayerBildPurchase.BuyBuild -= OnBuildingPurchased;
        PlayerLandPurchase.BuyLand -= OnTerritoryPurchased;
    }
}
