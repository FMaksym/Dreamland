using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SettingsPanel : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _playerInterfacePanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _clearDataWindow;

    [Inject] private PlayerTouchMovement _playerMovement;

    public void OnClickClose()
    {
        _settingsPanel.SetActive(false);
        _playerInterfacePanel.SetActive(true);
        _playerMovement.Moved(true);
    }

    public void OnClickClearData()
    {
        _clearDataWindow.SetActive(true);
    }

    public void OnClickAcceptClear()
    {
        DataManager.instance.ClearAllData();
        StartCoroutine(WaitAndLoadScene(1.0f, 0));
    }

    public void OnClickRejectClear()
    {
        _clearDataWindow.SetActive(false);
    }

    private IEnumerator WaitAndLoadScene(float time, int sceneIndex)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneIndex);
    }
}
