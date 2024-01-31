using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _sensetive;
    public Animator _animator;
    private Vector3 direction;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (IsMove())
        {
            Plane plane = new(Vector3.up, transform.position);
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                direction = ray.GetPoint(distance);
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(direction.x, transform.position.y, direction.z), _speed * Time.deltaTime);

            var offset = direction - transform.position;

            if (offset.magnitude > 0.5f)
            {
                transform.LookAt(direction);
            }
            else
            {
                _animator.SetBool("Move", false);
            }
        }
    }

    private bool IsMove()
    {
        if (Input.GetMouseButton(0))
        {
            _animator.SetBool("Move", true);
            return true;
        }
        else
        {
            _animator.SetBool("Move", false);
            return false;
        }
    }
}
