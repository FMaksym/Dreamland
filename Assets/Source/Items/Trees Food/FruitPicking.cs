using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FruitPicking : MonoBehaviour
{
    public bool isPickedUp;

    [SerializeField] private float _pickUpRadius;
    [SerializeField] private float _pickUpSpeed;
    [SerializeField] private Transform[] _startPosition;
    [SerializeField] private FruitGrowth _fruitGrowth;

    private bool isPlayerInRange;
    public Vector3[] _position;

    [Inject] private PlayerTouchMovement _player;

    private void Awake()
    {
        _position = new Vector3[_startPosition.Length];
        for (int i = 0; i < _startPosition.Length; i++)
        {
            _position[i] = _startPosition[i].position;
        }
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
            foreach (var fruit in _fruitGrowth.foodPrefabs)
            {
                fruit.transform.position = Vector3.MoveTowards(transform.position,
                _player.transform.position,
                _pickUpSpeed * Time.deltaTime);
            }

            _fruitGrowth.HarvestFood();
            isPickedUp = true;
            StartCoroutine(Wait(1));
        }
    }

    private void RemovePosition()
    {
        for (int i = 0; i < _position.Length; i++)
        {
            _fruitGrowth.foodPrefabs[i].transform.position = _position[i];
        }
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        RemovePosition();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _pickUpRadius);
    }
}
