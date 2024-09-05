using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ASyncLoader : MonoBehaviour
{
    [Header("Scene Name")]
    [SerializeField] private string _sceneName;

    [Header("Progressbar")]
    [SerializeField]private Image _progress;

    private void Start()
    {
        StartCoroutine(LoadGameASync(_sceneName));
    }

    IEnumerator LoadGameASync(string sceneLoadName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneLoadName);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            _progress.fillAmount = progressValue;
            yield return null;
        }
    }
}
