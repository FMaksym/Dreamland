using UnityEngine;

public class UIViewModel : MonoBehaviour
{
    [SerializeField] private UIModel model;
    [SerializeField] private UIView view;

    public void OnClickInventory()
    {
        view.OpenPanel(model, model.inventoryPanel);
    }

    public void OnClickMap()
    {
        view.OpenPanel(model, model.mapPanel);
    }

    public void OnClickSettings()
    {
        view.OpenPanel(model, model.settingsPanel);
    }

    public void OnClickShop()
    {
        view.OpenPanel(model, model.shopPanel);
    }


    public void OnClickCloseInventory()
    {
        view.ClosePanel(model, model.inventoryPanel);
    }
    public void OnClickCloseMap()
    {
        view.ClosePanel(model, model.mapPanel);
    }
    public void OnClickCloseSettings()
    {
        view.ClosePanel(model, model.settingsPanel);
    }
    public void OnClickCloseShop()
    {
        view.ClosePanel(model, model.shopPanel);
    }

    public void OnClickClearData()
    {
        view.OpenClearDataPanel(model);
    }

    public void OnClickAcceptClear()
    {
        view.AcceptClear();
    }

    public void OnClickRejectClear()
    {
        view.RejectClear(model);
    }

    public void OpenOffersPanel(GameObject panel)
    {
        view.OpenOffersPanel(model, panel);
    }
}
