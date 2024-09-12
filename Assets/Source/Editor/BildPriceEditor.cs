using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildPrice))]
public class BildPriceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BuildPrice bildPrice = (BuildPrice)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Price"))
        {
            bildPrice.AddPrice("", 0);
        }
        if (GUILayout.Button("Remove Price"))
        {
            bildPrice.RemovePrice(bildPrice._priceKeys.Count - 1);
        }
        GUILayout.EndHorizontal();
    }
}
