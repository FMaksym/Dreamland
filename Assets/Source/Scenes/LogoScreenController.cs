using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScreenController : MonoBehaviour
{
    [SerializeField] private float fadeInDuration = 2f;
    [SerializeField] private TMP_Text _madeByText;
    [SerializeField] private TMP_Text _logoText;

    private void Start()
    {
        StartCoroutine(FadeText());
    }

    IEnumerator FadeText()
    {
        Color startColor = _logoText.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Устанавливаем альфа-канал в 1 (полностью видимый)

        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime * fadeInDuration;
            _madeByText.color = Color.Lerp(startColor, targetColor, t);
            _logoText.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
