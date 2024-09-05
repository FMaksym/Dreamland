using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> _enemiesInRoom = new List<GameObject>();

    //public event Action OnRoomCleared; // Событие, вызываемое при очищении комнаты от монстров

    public delegate void RoomClear();
    public event RoomClear OnRoomCleared;

    public void RegisterEnemy(GameObject enemy)
    {
        _enemiesInRoom.Add(enemy);

        // Подписываемся на событие смерти монстра
        enemy.GetComponent<EnemyHealth>().OnEnemyDeath += HandleEnemyDeath;
    }

    private void HandleEnemyDeath(GameObject enemy)
    {
        enemy.GetComponent<EnemyHealth>().OnEnemyDeath -= HandleEnemyDeath;
        _enemiesInRoom.Remove(enemy);


        if (_enemiesInRoom.Count == 0)
        {
            // Если в комнате больше нет монстров, вызываем событие
            OnRoomCleared?.Invoke();
        }
    }
}
