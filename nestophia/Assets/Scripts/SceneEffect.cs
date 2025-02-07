using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneEffect : MonoBehaviour
{
    // 짧은 페이드 효과 사용법 - 각 사용법은 해당하는 인스턴스(검은색 이미지 등)가 있어야 하므로 일단 설정했던 대로 설정했음
    // 씬 전환마다 어떤 효과를 넣을지 생각하고 인스턴스 만들고 코드 적용
    // nextSceneName = "LongEffect1";
    // FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);

    public Image fadeImage;
    public float fadeSpeed = 1.0f;

    private bool isFadingOut = false;

    void Start()
    {
        StartCoroutine(FadeIn());
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
            Destroy(fadeImage, 3.0f);
            yield return null;
        }
    }

    IEnumerator FadeOutAndLoadScene(string sceneName) {
        if (isFadingOut) {
            yield break;
        }
        isFadingOut = true;

        float alpha = 0.0f;
        while (alpha < 1) {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
