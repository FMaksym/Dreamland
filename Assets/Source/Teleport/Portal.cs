using System.Collections;
using UnityEngine;
using Zenject;

public class Portal : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Vector3 _teleportPosition;
    [SerializeField] private Vector3 _positionOffset;

    [Inject] private PlayerTouchMovement _player;

    private void Update()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        bool isPlayerInRange = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (Collider collider in colliders)
        {
            if (collider.transform == _player.transform && !isPlayerInRange)
            {
                isPlayerInRange = true;
                TeleportPlayer(_teleportPosition);
            }
        }
    }

    private void TeleportPlayer(Vector3 position)
    {
        _player.CanMoved(false);
        _player.gameObject.SetActive(false);
        _player.transform.position = _teleportPosition;
        StartCoroutine(Wait(0.5f));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        _player.gameObject.SetActive(true);
        _player.CanMoved(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + _positionOffset, _radius);
    }
}
