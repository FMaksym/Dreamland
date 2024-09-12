using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LandPrice))]
public class LandPriceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LandPrice landPrice = (LandPrice)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Price"))
        {
            landPrice.AddPrice("", 0);
        }
        if (GUILayout.Button("Remove Price"))
        {
            landPrice.RemovePrice(landPrice._priceKeys.Count - 1);
        }
        GUILayout.EndHorizontal();
    }
}
