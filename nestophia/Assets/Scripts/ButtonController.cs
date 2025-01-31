using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject newPostPanel;
    public GameObject settingPowerBtn;

    public void ClickCancelPostBtn()
    {
        Debug.Log("Cancel Post Button Clicked");
        newPostPanel.SetActive(false);
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
}
