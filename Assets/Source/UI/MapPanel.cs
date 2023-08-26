using UnityEngine;
using Zenject;

public class MapPanel : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _playerInterfacePanel;
    [SerializeField] private GameObject _mapPanel;

    [Inject] private PlayerTouchMovement _playerMovement;

    public void OnClickClose()
    {
        _mapPanel.SetActive(false);
        _playerInterfacePanel.SetActive(true);
        _playerMovement.Moved(true);
    }
}
