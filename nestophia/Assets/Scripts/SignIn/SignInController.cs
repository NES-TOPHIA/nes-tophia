using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SignInController : MonoBehaviour
{
    public TMP_InputField nicknameInput;
    public TMP_InputField IDInput;
    public GameObject signInPanel;
    public GameObject blankErrorMessage;

    private string nextSceneName;
    private string nickname;
    private string ID;

    public void SetID()
    {
        blankErrorMessage.SetActive(false);
        ID = IDInput.GetComponent<TMP_InputField>().text;
        IDDuplicateCheck();
        if (IDBlankCheck() == true) 
        {
            Debug.Log(ID);
            ConfirmID();
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

    private void IDDuplicateCheck()
    {
        // 서버 연결
    }

    private void NickNameDuplicateCheck()
    {
        // 서버 연결
    }

    private bool IDBlankCheck()
    {
        if (ID != "")
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

    private void ConfirmID()
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
