using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class DataPanel : MonoBehaviour
{
    public DataManager data;

    [Header("Panels")]
    [SerializeField] private GameObject _playerInterfacePanel;
    [SerializeField] private GameObject _dataPanel;
    [SerializeField] public TMP_Text _dataPathText;

    [Inject] private PlayerTouchMovement _playerMovement;

    private void Start()
    {
        _dataPathText.text = SaveSystem.GetPersistentDataPath();
    }

    public void OnClickClose()
    {
        _dataPanel.SetActive(false);
        _playerInterfacePanel.SetActive(true);
        _playerMovement.Moved(true);
    }

    public void OnClickSave()
    {
        data.Save();
    }
}
