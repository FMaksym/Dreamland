using UnityEngine;
using Zenject;

public class UIModel : MonoBehaviour
{
    [Header("Panels")]
    public GameObject playerInterfacePanel;
    public GameObject inventoryPanel;
    public GameObject mapPanel;
    public GameObject settingsPanel;
    public GameObject shopPanel;
    public GameObject currenOffersPanel;
    public GameObject clearDataWindow;

    [Inject] public PlayerTouchMovement playerMovement;
}
