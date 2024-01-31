using System.Collections;
using UnityEngine;
using Zenject;

public class MiningResourceTransfer : MonoBehaviour
{
    public float _speed;
    public float _radius;
    public ResourceMine ResourceMine;

    private bool _isCollecting;
    private Vector3 _playerPosition;

    [Inject] private PlayerTouchMovement _player;

    private void FixedUpdate()
    {
        FindPlayer();
        if (_isCollecting)
        {
            CollectResources();
        }
    }

    private void FindPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<PlayerTouchMovement>())
            {
                _isCollecting = true;
                _playerPosition = collider.transform.position;
                return;
            }
        }
        _isCollecting = false;
    }

    private void CollectResources()
    {
        foreach (GameObject item in ResourceMine.ResourceObjects)
        {
            if (item.activeInHierarchy)
            {
                Collect(item);
            }
        }
        ResourceMine._currentProduction = 0;
    }

    private void Collect(GameObject item)
    {
        Vector3 originalPosition = item.transform.position;
        while (Vector3.Distance(item.transform.position, _playerPosition + new Vector3(0f, 1f, 0f)) > 0.05f)
        {
            item.transform.position = Vector3.MoveTowards(item.transform.position, _playerPosition + new Vector3(0f, 1f, 0f), Time.deltaTime * _speed);
        }
        item.transform.position = originalPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
