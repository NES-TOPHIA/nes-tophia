using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRSceneEffect : MonoBehaviour
{
    public Image fadeImage;
    public GameObject fadeCanvas;
    public float fadeSpeed = 1.0f;

    private bool isFadingOut = false;

    void Update()
    {
        string lastScene = PlayerPrefs.GetString("LastScene");
        if (SceneManager.GetActiveScene().name != lastScene) {
            StartCoroutine(FadeIn());
        }
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }

    IEnumerator FadeIn() 
    {
        float alpha = 1.0f;
        while (alpha > 0) {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeCanvas.SetActive(false);
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
    }

    IEnumerator FadeOutAndLoadScene(string sceneName) {
        if (isFadingOut) {
            yield break;
        }
        isFadingOut = true;

        fadeCanvas.SetActive(true);
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);

        float alpha = 0.0f;
        while (alpha < 1) {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
