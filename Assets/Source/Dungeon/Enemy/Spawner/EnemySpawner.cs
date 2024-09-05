using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField, Min(1)] private int _amountOfEnemySpawns;
    [SerializeField] private GameObject _enemysParent;
    [SerializeField] private List<Transform> _spawnPointsList;
    [SerializeField] private List<GameObject> _enemyPrefabsList;
    [SerializeField] private RoomManager _roomManager;

    private List<Transform> _spawnPointList = new();
    //private List<GameObject> _enemyList = new();

    private void Awake()
    {
        if (_spawnPointsList != null && _enemyPrefabsList != null)
        {
            SpawnEnemys();
        }
    }

    private void SpawnEnemys()
    {
        _spawnPointList = new List<Transform>(_spawnPointsList);

        for (int i = 0; i < _amountOfEnemySpawns; i++)
        {
            Transform spawnPosition;
            GameObject enemyPrefab = _enemyPrefabsList[GetRandomListIndex(_enemyPrefabsList)];

            int randomIndex = GetRandomListIndex(_spawnPointList);
            spawnPosition = _spawnPointList[randomIndex];
            _spawnPointList.RemoveAt(randomIndex);

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity, _enemysParent.transform);

            if (enemy != null)
            {
                _roomManager.RegisterEnemy(enemy);
                //_enemyList.Add(enemy);
            }
            else
            {
                Debug.Log("Enemy NULL");
            }
        }
    }

    private int GetRandomListIndex<T>(List<T> list)
    {
        int randIndex = Random.Range(0, list.Count - 1);

        return randIndex;
    }
}
