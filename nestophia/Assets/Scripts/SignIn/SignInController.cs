using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SignInController : MonoBehaviour
{
    public TMP_InputField nicknameInput;
    public TMP_InputField emailInput;
    public GameObject signInPanel;
    public GameObject blankErrorMessage;

    private string nextSceneName;
    private string nickname;
    private string email;

    public void SetEmail()
    {
        blankErrorMessage.SetActive(false);
        email = emailInput.GetComponent<TMP_InputField>().text;
        EmailDuplicateCheck();
        if (EmailBlankCheck() == true) 
        {
            Debug.Log(email);
            ConfirmEmail();
        }
    }

    public void SetNickName()
    {
        blankErrorMessage.SetActive(false);
        nickname = nicknameInput.GetComponent<TMP_InputField>().text;
        NickNameDuplicateCheck();
        if (NicknameBlankCheck() == true) 
        {
            Debug.Log(nickname);
            ConfirmNickname();
        }
    }

    private void EmailDuplicateCheck()
    {
        // 서버 연결
    }

    private void NickNameDuplicateCheck()
    {
        // 서버 연결
    }

    private bool EmailBlankCheck()
    {
        if (email != "")
        {
            return true;
        } 
        else
        {
            blankErrorMessage.SetActive(true);
            return false;
        }
    }

    private bool NicknameBlankCheck()
    {
        if (nickname != "")
        {
            return true;
        } 
        else
        {
            blankErrorMessage.SetActive(true);
            return false;
        }
    }

    private void ConfirmEmail()
    {
        Debug.Log("Sign In Button Clicked");
        signInPanel.SetActive(false);
    }

    private void ConfirmNickname()
    {
        Debug.Log("Confirm Name Button Clicked");
        nextSceneName = "HomeScene";
        FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
        // SceneManager.LoadScene(nextSceneName);
    }
}
