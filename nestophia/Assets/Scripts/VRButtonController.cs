using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using BackEnd;

public class VRButtonController : MonoBehaviour
{
    public GameObject myFeedPanel;
    public GameObject newPostPanel;
    public GameObject settingPowerBtn;
    public GameObject DMPanel;
    public GameObject settingPanel;

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

    public void ClickDMBtn()
    {
        Debug.Log("DM Button Clicked");
        DMPanel.SetActive(!DMPanel.activeSelf);
    }

    public void ClickVRHomeBtn()
    {
        Debug.Log("VRHome Button Clicked");
        nextSceneName = "VRHomeScene";
        FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
        // SceneManager.LoadScene(nextSceneName);
    }

    public void ClickMenuBtn()
    {
        Debug.Log("Menu Button Clicked");
        settingPowerBtn.SetActive(!settingPowerBtn.activeSelf);
    }
    
    public void ClickPowerBtn()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // 어플리케이션 종료
        #endif  
    }

    public void ClickSettingBtn()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }
    
    public void ClickVRMemberWithdrawBtn()
    {
        // 즉시 탈퇴
        Backend.BMember.WithdrawAccount(callback  => {
            // 이후 처리
            Debug.Log("회원 탈퇴 성공");
            SceneManager.LoadScene("VRIntroScene"); // 시작 화면으로 이동
        });
    }

    public void ClickVRCarpet()
    {
        Debug.Log("VRFurniture Scene Loading...");
        nextSceneName = "VRFurnitureScene";
        FindObjectOfType<VRSceneEffect>().FadeToScene(nextSceneName);
    }

    public void ClickVRSignUpBtn()
    {
        SceneManager.LoadScene("VRSignUpScene");
    }

    public void ClickVRSignInBtn()
    {
        SceneManager.LoadScene("VRSignInScene");
    }
}
