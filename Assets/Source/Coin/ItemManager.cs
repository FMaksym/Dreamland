using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private float _speed = 10f;
    [SerializeField, Min(0)] private float _radius;

    private void LateUpdate()
    {
        FindPlayer();
    }

    public void FindPlayer()
    {
        Collider[] _collider = Physics.OverlapSphere(transform.position, _radius);
        foreach (var collider in _collider)
        {
            if (collider.GetComponent<PlayerTouchMovement>())
            {
                transform.position = Vector3.MoveTowards(transform.position, collider.transform.position + new Vector3(0f, 1f, 0f), Time.deltaTime * _speed);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
