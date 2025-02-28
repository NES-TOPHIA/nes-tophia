using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    public GameObject myFeedPanel;
    public GameObject newPostPanel;
    public GameObject settingPowerBtn;
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

    public void ClickHomeBtn()
    {
        Debug.Log("Home Button Clicked");
        nextSceneName = "HomeScene";
        FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
        // SceneManager.LoadScene(nextSceneName);
    }

    public void ClickPowerBtn()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // 어플리케이션 종료
        #endif  
    }
}
