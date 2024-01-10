using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIViewModel : MonoBehaviour
{
    [SerializeField] private UIModel model;

    public void OnClickInventory()
    {
        OpenPanel(model.inventoryPanel);
    }

    public void OnClickMap()
    {
        OpenPanel(model.mapPanel);
    }

    public void OnClickSettings()
    {
        OpenPanel(model.settingsPanel);
    }

    public void OnClickShop()
    {
        OpenPanel(model.shopPanel);
    }


    public void OnClickCloseInventory()
    {
        ClosePanel(model.inventoryPanel);
    }
    public void OnClickCloseMap()
    {
        ClosePanel(model.mapPanel);
    }
    public void OnClickCloseSettings()
    {
        ClosePanel(model.settingsPanel);
    }
    public void OnClickCloseShop()
    {
        ClosePanel(model.shopPanel);
    }

    public void OnClickClearData()
    {
        model.clearDataWindow.SetActive(true);
    }

    public void OnClickAcceptClear()
    {
        DataManager.instance.ClearAllData();
        StartCoroutine(WaitAndLoadScene(1.0f, 0));
    }

    public void OnClickRejectClear()
    {
        model.clearDataWindow.SetActive(false);
    }

    public void OpenOffersPanel(GameObject panel)
    {
        if (model.currenOffersPanel != panel)
        {
            model.currenOffersPanel.SetActive(false);
            panel.SetActive(true);
            model.currenOffersPanel = panel;
        }
    }

    private void OpenPanel(GameObject panelToOpen)
    {
        panelToOpen.SetActive(true);
        model.playerInterfacePanel.SetActive(false);
        model.playerMovement.Moved(false);
    }

    private void ClosePanel(GameObject panelToClose)
    {
        model.playerInterfacePanel.SetActive(true);
        panelToClose.SetActive(false);
        model.playerMovement.Moved(true);
    }

    private IEnumerator WaitAndLoadScene(float time, int sceneIndex)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneIndex);
    }
}
