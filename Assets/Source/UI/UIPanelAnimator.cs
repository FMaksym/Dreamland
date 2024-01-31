using UnityEngine;
using DG.Tweening;

public class UIPanelAnimator : MonoBehaviour
{
    [SerializeField] private RectTransform panelTransform;
    [SerializeField] private float animationDuration = 0.5f;
    [SerializeField] private Vector3 openScale = Vector3.one;
    [SerializeField] private Vector3 closedScale = Vector3.zero;

    private void OnEnable()
    {
        OpenPanelAnimation();
    }

    private void OnDisable()
    {
        ClosePanelAnimation();
        DOTween.Kill(this);
    }

    private void OpenPanelAnimation()
    {
        panelTransform.DOScale(openScale, animationDuration);
    }

    private void ClosePanelAnimation()
    {
        panelTransform.DOScale(closedScale, animationDuration);
    }
}
