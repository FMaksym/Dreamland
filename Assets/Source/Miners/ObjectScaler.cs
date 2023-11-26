using UnityEngine;
using DG.Tweening;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField] private float _duration = 1.0f;
    [SerializeField] private Vector3 _startScale = new (0.1f, 0.1f, 0.1f);
    [SerializeField] private Vector3 _endScale;

    private void Awake()
    {
        transform.localScale = _startScale;
    }

    private void Start()
    {
        ScaleObject();
    }

    private void ScaleObject()
    {
        transform.DOScale(_endScale, _duration)
            .SetEase(Ease.OutBack);
    }
}
