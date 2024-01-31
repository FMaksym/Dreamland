using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIView : MonoBehaviour
{
    public void OpenPanel(UIModel model, RectTransform panelTransform)
    {
        model.playerInterfacePanel.gameObject.SetActive(false);
        model.playerMovement.Moved(false);
        panelTransform.gameObject.SetActive(true);
        OpenPanelAnimation(model, panelTransform);
    }

    public void ClosePanel(UIModel model, RectTransform panelToClose)
    {
        ClosePanelAnimation(model, panelToClose, () => 
        {
            panelToClose.gameObject.SetActive(false);
            model.playerInterfacePanel.gameObject.SetActive(true);
            model.playerMovement.Moved(true);
        });
        
    }

    public void OpenClearDataPanel(UIModel model)
    {
        model.clearDataWindow.gameObject.SetActive(true);
        OpenPanelAnimation(model, model.clearDataWindow);
    }

    public void AcceptClear()
    {
        DataManager.instance.ClearAllData();
        StartCoroutine(WaitAndLoadScene(1.0f, 0));
    }

    public void RejectClear(UIModel model)
    {
        ClosePanelAnimation(model, model.clearDataWindow, () =>
        {
            model.clearDataWindow.gameObject.SetActive(false);
        });
    }

    public void OpenOffersPanel(UIModel model, RectTransform panel)
    {
        if (model.currenOffersPanel != panel)
        {
            model.currenOffersPanel.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
            model.currenOffersPanel = panel;
        }
    }

    private void OpenPanelAnimation(UIModel model, RectTransform panelTransform)
    {
        panelTransform.DOScale(model.openScale, model.animationDuration);
    }

    private void ClosePanelAnimation(UIModel model, RectTransform panelTransform, TweenCallback onCompleteCallback)
    {
        panelTransform.DOScale(model.closedScale, model.animationDuration).OnComplete(onCompleteCallback);
    }

    private IEnumerator WaitAndLoadScene(float time, int sceneIndex)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneIndex);
    }
}