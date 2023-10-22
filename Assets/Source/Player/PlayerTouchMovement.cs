using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerTouchMovement : MonoBehaviour
{
    public float _speed;
    public Animator _animator;

    private bool CanMove = true;
    private Finger _movementFinger;
    private Vector2 _movementAmount;

    [SerializeField] private Vector2 _joystickSize = new (500, 500);
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private NavMeshAgent _player;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleFingerUp;
        ETouch.Touch.onFingerMove += HandleFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleFingerUp;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        Vector3 scaledMovement = _player.speed * Time.deltaTime * new Vector3(_movementAmount.x, 0, _movementAmount.y);

        _player.Move(scaledMovement);

        transform.LookAt(_player.transform.position + scaledMovement, Vector3.up);

        _animator.SetFloat("MoveX", _movementAmount.x);
        _animator.SetFloat("MoveZ", _movementAmount.y);
    }

    private void HandleFingerMove(Finger movedFinger)
    {
        if (movedFinger == _movementFinger)
        {
            if (CanMove) 
            {
                Vector2 knobPosition;
                float maxMovement = _joystickSize.x / 2f;
                ETouch.Touch currentTouch = movedFinger.currentTouch;

                if (Vector2.Distance(currentTouch.screenPosition, _joystick.RectTransform.anchoredPosition) > maxMovement)
                {
                    knobPosition = (currentTouch.screenPosition - _joystick.RectTransform.anchoredPosition).normalized * maxMovement;
                }
                else
                {
                    knobPosition = currentTouch.screenPosition - _joystick.RectTransform.anchoredPosition;
                }

                _joystick.Knob.anchoredPosition = knobPosition;
                _movementAmount = knobPosition / maxMovement; 
            }
        }
    }

    private void HandleFingerUp(Finger lostFinger)
    {
        if (lostFinger == _movementFinger)
        {
            if (CanMove)
            {
                _movementFinger = null;
                _joystick.Knob.anchoredPosition = Vector2.zero;
                _joystick.gameObject.SetActive(false);
                _movementAmount = Vector2.zero;
            }
        }
    }

    private void HandleFingerDown(Finger touchedFinger)
    {
        if (_movementFinger == null && touchedFinger.screenPosition.x <= Screen.width / 1.2f && touchedFinger.screenPosition.y <= Screen.height / 1.3f)
        {
            if (CanMove)
            {
                _movementFinger = touchedFinger;
                _movementAmount = Vector2.zero;
                _joystick.gameObject.SetActive(true);
                _joystick.RectTransform.sizeDelta = _joystickSize;
                _joystick.RectTransform.anchoredPosition = ClampStartPosition(touchedFinger.screenPosition);
            }
        }
    }

    private Vector2 ClampStartPosition(Vector2 startPosition)
    {
        if (startPosition.x < _joystickSize.x / 2f)
        {
            startPosition.x = _joystickSize.x / 2f;
        }

        if (startPosition.y < _joystickSize.y / 2f)
        {
            startPosition.y = _joystickSize.y / 2f;
        }
        else if (startPosition.y > Screen.height - _joystickSize.y / 2f)
        {
            startPosition.y = Screen.height - _joystickSize.y / 2f;
        }

        return startPosition;
    }

    public void Moved(bool value)
    {
        CanMove = value;

        if (!CanMove)
        {
            _joystick.gameObject.SetActive(false);
            _movementAmount = Vector2.zero;
            _animator.SetFloat("MoveX", 0f);
            _animator.SetFloat("MoveZ", 0f);
        }
    }
}
