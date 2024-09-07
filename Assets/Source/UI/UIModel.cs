using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIModel : MonoBehaviour
{
    [Header("Panels")]
    public RectTransform playerInterfacePanel;
    public RectTransform inventoryPanel;
    public RectTransform mapPanel;
    public RectTransform settingsPanel;
    public RectTransform shopPanel;
    public RectTransform adRewardPanel;
    public RectTransform currenOffersPanel;
    public RectTransform clearDataWindow;

    [Header("Ad Reward Parametres")]
    public Image rewardImage;
    public TMP_Text rewardText;
    public Dictionary<string, Sprite> itemsDictionary;
    [SerializeField] private List<string> itemsNames;
    [SerializeField] private List<Sprite> itemsIcons;

    [Header("Animation Parametres")]
    public float animationDuration = 0.5f;
    public Vector3 openScale = Vector3.one;
    public Vector3 closedScale = new (0.25f, 0.25f, 0.25f);

    [Inject] public PlayerTouchMovement playerMovement;

    private void Awake()
    {
        itemsDictionary = new Dictionary<string, Sprite>();

        if (itemsNames.Count == itemsIcons.Count)
        {
            for (int i = 0; i < itemsNames.Count; i++)
            {
                if (!itemsDictionary.ContainsKey(itemsNames[i]))
                {
                    itemsDictionary.Add(itemsNames[i], itemsIcons[i]);
                }
            }
        }
    }
}
