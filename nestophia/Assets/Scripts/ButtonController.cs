using UnityEngine;
using UnityEngine.SceneManagement;
using BackEnd;

public class ButtonController : MonoBehaviour
{
    public GameObject myFeedPanel;
    public GameObject newPostPanel;
    public GameObject settingPowerBtn;
    public GameObject DMPanel;
    public GameObject settingPanel;
    public GameObject galleryPanel;

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

    public void ClickHomeBtn()
    {
        Debug.Log("Home Button Clicked");
        nextSceneName = "HomeScene";
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
    
    public void ClickMemberWithdrawBtn()
    {
        // 즉시 탈퇴
        Backend.BMember.WithdrawAccount(callback  => {
            // 이후 처리
            Debug.Log("회원 탈퇴 성공");
            SceneManager.LoadScene("IntroScene"); // 시작 화면으로 이동
        });
    }

    public void ClickSignUpBtn()
    {
        SceneManager.LoadScene("SignUpScene");
    }

    public void ClickSignInBtn()
    {
        SceneManager.LoadScene("SignInScene");
    }

    public void ClickGalleryBtn()
    {
        galleryPanel.SetActive(!galleryPanel.activeSelf);
    }
}
