using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    public GameObject myFeedPanel;
    public GameObject newPostPanel;
    public GameObject settingPowerBtn;
    public GameObject signInPanel;
    public GameObject DMPanel;

    private string nextSceneName;

    public void ClickCancelPostBtn()
    {
        Debug.Log("Cancel Post Button Clicked");
        newPostPanel.SetActive(false);
    }

    public void ClickAddPostBtn()
    {
        Debug.Log("Add Post Button Clicked");
        newPostPanel.SetActive(true);
    }

    public void ClickCloseFeedBtn()
    {
        Debug.Log("Close Feed Button Clicked");
        myFeedPanel.SetActive(false);
    }

    public void ClickUploadPostBtn()
    {
        Debug.Log("Upload Post Button Clicked");
        newPostPanel.SetActive(false);
        // 여기에 게시물 업로드 코드 작성 or 다른 스크립트 생성
    }

    public void ClickMenuBtn()
    {
        Debug.Log("Menu Button Clicked");
        settingPowerBtn.SetActive(!settingPowerBtn.activeSelf);
    }

    public void ClickDMBtn()
    {
        Debug.Log("DM Button Clicked");
        DMPanel.SetActive(!DMPanel.activeSelf);
    }

    public void ClickSignInBtn()
    {
        Debug.Log("Sign In Button Clicked");
        signInPanel.SetActive(false);
        //nextSceneName = "HomeScene";
        //FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
        //SceneManager.LoadScene(nextSceneName);
    }
    
    public void ClickConfirmNameBtn()
    {
        Debug.Log("Confirm Name Button Clicked");
        nextSceneName = "HomeScene";
        //FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }

    public void ClickHomeBtn()
    {
        Debug.Log("Home Button Clicked");
        nextSceneName = "HomeScene";
        //FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}
