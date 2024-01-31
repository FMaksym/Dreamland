using UnityEngine;
using Zenject;

public class UIModel : MonoBehaviour
{
    [Header("Panels")]
    public RectTransform playerInterfacePanel;
    public RectTransform inventoryPanel;
    public RectTransform mapPanel;
    public RectTransform settingsPanel;
    public RectTransform shopPanel;
    public RectTransform currenOffersPanel;
    public RectTransform clearDataWindow;

    [Header("Animation Parametres")]
    public float animationDuration = 0.5f;
    public Vector3 openScale = Vector3.one;
    public Vector3 closedScale = new (0.25f, 0.25f, 0.25f);

    [Inject] public PlayerTouchMovement playerMovement;
}
