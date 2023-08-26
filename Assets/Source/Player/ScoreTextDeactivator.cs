using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreTextDeactivator : MonoBehaviour
{
    private float _time = 0.25f;
    [Inject] private Camera _PlayerCamera;

    private void OnEnable()
    {
        Invoke("InActive", _time);
    }

    private void FixedUpdate()
    {
        transform.LookAt(transform.position + _PlayerCamera.transform.forward);
    }

    private void InActive()
    {
        gameObject.SetActive(false);
    }
}
