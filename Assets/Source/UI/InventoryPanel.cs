using UnityEngine;
using Zenject;

public class InventoryPanel : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _playerInterfacePanel;
    [SerializeField] private GameObject _inventoryPanel;

    [Inject] private PlayerTouchMovement _playerMovement;

    public void OnClickClose()
    {
        _inventoryPanel.SetActive(false);
        _playerInterfacePanel.SetActive(true);
        _playerMovement.Moved(true);
    }
}
