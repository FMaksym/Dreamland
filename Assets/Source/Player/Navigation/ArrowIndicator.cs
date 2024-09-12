using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowIndicator : MonoBehaviour
{
    [SerializeField] private float hideDistance = 5f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform playerTransform;
    public Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
        _spriteRenderer.enabled = true;
    }

    public void Hide()
    {
        _spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = _target.position - playerTransform.position;
            //direction.y = 0;

            float distance = direction.magnitude;

            if (distance < hideDistance)
            {
                Hide();
            }
            else if (distance > hideDistance)
            {
                if (!_spriteRenderer.enabled)
                {
                    _spriteRenderer.enabled = true;
                }

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Euler(90, targetRotation.eulerAngles.y, 0);
            }
        }
    }
}
