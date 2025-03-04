using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
// using BackEnd;

public class NameController : MonoBehaviour
{
    public TMP_InputField nicknameInput;
    public GameObject blankErrorMessage;
    public GameObject duplicateErrorMessage;

    private string nextSceneName;
    private string nickname;

    public void SetNickName()
    {
        blankErrorMessage.SetActive(false);
        duplicateErrorMessage.SetActive(false);

        nickname = nicknameInput.GetComponent<TMP_InputField>().text;
        if (BlankCheck() == true) 
        {
            if (NickNameDuplicateCheck() == true)
            {
                Debug.Log(nickname);
                ConfirmNickname();
            }
            else
            {
                duplicateErrorMessage.SetActive(true);
            }
        }
        else
        {
            blankErrorMessage.SetActive(true);
        }
    }

    private bool BlankCheck()
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

    private bool NickNameDuplicateCheck()
    {
        // 서버 연결
        //BackendReturnObject bro = Backend.BMember.CheckNicknameDuplication("thebackend");
        //if (bro.IsSuccess())
        //{
        //  Debug.Log("해당 닉네임은 중복되지 않습니다.");
        //  return true;
        //}
        //else
        //{
        //  Debug.Log("해당 닉네임은 중복됩니다.");
        //  return false;
        //}
        return true;
    }

    private void ConfirmNickname()
    {
        Debug.Log("Confirm Name Button Clicked");
        nextSceneName = "HomeScene";
        FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
        // SceneManager.LoadScene(nextSceneName);
    }
}
