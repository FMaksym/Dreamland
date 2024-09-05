using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    [SerializeField] private int _amountRoomForSpawn;
    [SerializeField] private Vector3 _spawnOffset;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private GameObject _roomParent;
    [SerializeField] private List<GameObject> _dungeonsRoomList;

    [SerializeField] private NavMeshManager _navMeshManager;


    private List<GameObject> _spawnedRooms = new();

    private void Awake()
    {
        SpawnRoom();
        _navMeshManager.BakeNavMesh();
    }

    private void SpawnRoom()
    {
        for (int i = 0; i < _amountRoomForSpawn; i++)
        {
            GameObject room;
            do
            {
                room = _dungeonsRoomList[GetRandomListIndex()];
            } while (_spawnedRooms.Contains(room));

            GameObject newRoom = Instantiate(room, _roomParent.transform);
            newRoom.SetActive(true);

            newRoom.transform.position = _spawnPosition;
            _spawnPosition += _spawnOffset;

            _dungeonsRoomList.Remove(room);
            _spawnedRooms.Add(newRoom);
        }
    }

    private int GetRandomListIndex()
    {
        int randIndex = UnityEngine.Random.Range(0, _dungeonsRoomList.Count - 1);

        return randIndex;
    }
}
