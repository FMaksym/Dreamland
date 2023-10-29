using UnityEngine;
using Zenject;

public class PlayerInterfacePanel : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _playerInterfacePanel;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _mapPanel;
    [SerializeField] private GameObject _settingsPanel;

    [Header("Panels")]
    [SerializeField] private GameObject _dataPanel;

    [Inject] private PlayerTouchMovement _playerMovement;

    public void OnClickInventory()
    {
        OpenClosePanels(_playerInterfacePanel, _inventoryPanel);
    }
    public void OnClickMap()
    {
        OpenClosePanels(_playerInterfacePanel, _mapPanel);
    }
    public void OnClickSettings()
    {
        OpenClosePanels(_playerInterfacePanel, _settingsPanel);
    }

    private void OpenClosePanels(GameObject panelToClose, GameObject panelToOpen)
    {
        panelToClose.SetActive(false);
        panelToOpen.SetActive(true);
        _playerMovement.Moved(false);
    }

    public void OnClickData()
    {
        OpenClosePanels(_playerInterfacePanel, _dataPanel);
    }
}
