using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIView : MonoBehaviour
{
    public void OpenPanel(UIModel model, GameObject panelToOpen)
    {
        panelToOpen.SetActive(true);
        model.playerInterfacePanel.SetActive(false);
        model.playerMovement.Moved(false);
    }

    public void ClosePanel(UIModel model, GameObject panelToClose)
    {
        model.playerInterfacePanel.SetActive(true);
        panelToClose.SetActive(false);
        model.playerMovement.Moved(true);
    }

    public void OpenClearDataPanel(UIModel model)
    {
        model.clearDataWindow.SetActive(true);
    }

    public void AcceptClear()
    {
        DataManager.instance.ClearAllData();
        StartCoroutine(WaitAndLoadScene(1.0f, 0));
    }

    public void RejectClear(UIModel model)
    {
        model.clearDataWindow.SetActive(false);
    }

    public void OpenOffersPanel(UIModel model, GameObject panel)
    {
        if (model.currenOffersPanel != panel)
        {
            model.currenOffersPanel.SetActive(false);
            panel.SetActive(true);
            model.currenOffersPanel = panel;
        }
    }

    private IEnumerator WaitAndLoadScene(float time, int sceneIndex)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneIndex);
    }
}
