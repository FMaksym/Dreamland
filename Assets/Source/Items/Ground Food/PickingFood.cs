using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PickingFood : MonoBehaviour
{
    public bool isPickedUp;

    [SerializeField] private float _pickUpRadius;
    [SerializeField] private float _pickUpSpeed;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private GrowFood _growFood;

    private bool isPlayerInRange;
    private Vector3 _position;

    [Inject] private PlayerTouchMovement _player;

    private void Awake()
    {
        _position = _startPosition.localPosition;//
    }

    private void Update()
    {
        FindPlayer();
        if (isPlayerInRange)
        {
            PickUp();
        }
    }

    private void FindPlayer()
    {
        isPlayerInRange = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _pickUpRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<PlayerTouchMovement>())
            {
                isPlayerInRange = true;
                PickUp();
            }
        }
    }

    private void PickUp()
    {
        if (!isPickedUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                _player.transform.position, 
                _pickUpSpeed * Time.deltaTime);

            _growFood.HarvestFood();
            isPickedUp = true;
            transform.localPosition = _position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _pickUpRadius);
    }
}
