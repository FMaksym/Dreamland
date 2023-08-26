using UnityEngine;
using Zenject;

public class SettingsPanel : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _playerInterfacePanel;
    [SerializeField] private GameObject _settingsPanel;

    [Inject] private PlayerTouchMovement _playerMovement;

    public void OnClickClose()
    {
        _settingsPanel.SetActive(false);
        _playerInterfacePanel.SetActive(true);
        _playerMovement.Moved(true);
    }
}
