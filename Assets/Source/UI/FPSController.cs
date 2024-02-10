using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private float fpsCount = 0f;
    [SerializeField] private float updateTime = 0.2f;

    [SerializeField] private TMP_Text fpsText;

    private void UpdateFps()
    {
        updateTime -= Time.deltaTime;
        if (updateTime <= 0)
        {
            fpsCount = 1f / Time.unscaledDeltaTime;
            fpsText.text = "Fps: " + Mathf.Round(fpsCount);
            updateTime = 0.2f;
        }
    }

    private void Update()
    {
        UpdateFps();
    }
}
