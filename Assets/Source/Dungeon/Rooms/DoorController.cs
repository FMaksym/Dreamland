using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool _IsStartDoor = false;
    [SerializeField] private Transform _doorTransform;
    [SerializeField] private float _duration = 1f; 
    [SerializeField] private Vector3 _targetRotation = new Vector3(0, 100, 0);
    [SerializeField] private RoomManager _roomManager;

    private void OnEnable()
    {
        _roomManager.OnRoomCleared += OpenDoor;
    }

    private void Start()
    {
        if (_IsStartDoor)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        Tweener tweener = _doorTransform.DORotate(_targetRotation, _duration);

        tweener.OnComplete(() => { tweener.Kill(); });
    }

    private void OnDestroy()
    {
        _roomManager.OnRoomCleared -= OpenDoor;
    }
}
