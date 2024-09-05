using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> _enemiesInRoom = new List<GameObject>();

    //public event Action OnRoomCleared; // �������, ���������� ��� �������� ������� �� ��������

    public delegate void RoomClear();
    public event RoomClear OnRoomCleared;

    public void RegisterEnemy(GameObject enemy)
    {
        _enemiesInRoom.Add(enemy);

        // ������������� �� ������� ������ �������
        enemy.GetComponent<EnemyHealth>().OnEnemyDeath += HandleEnemyDeath;
    }

    private void HandleEnemyDeath(GameObject enemy)
    {
        enemy.GetComponent<EnemyHealth>().OnEnemyDeath -= HandleEnemyDeath;
        _enemiesInRoom.Remove(enemy);


        if (_enemiesInRoom.Count == 0)
        {
            // ���� � ������� ������ ��� ��������, �������� �������
            OnRoomCleared?.Invoke();
        }
    }
}
