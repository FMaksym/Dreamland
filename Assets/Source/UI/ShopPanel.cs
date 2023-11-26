using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopPanel : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _playerInterfacePanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _currenOffersPanel;

    [Inject] private PlayerTouchMovement _playerMovement;

    public void OpenOffersPanel(GameObject panel)
    {
        if (_currenOffersPanel != panel)
        {
            _currenOffersPanel.SetActive(false);
            panel.SetActive(true);
            _currenOffersPanel = panel;
        }
    }

    public void OnClickClosePanel()
    {
        _shopPanel.SetActive(false);
        _playerInterfacePanel.SetActive(true);
        _playerMovement.Moved(true);
    }
}
