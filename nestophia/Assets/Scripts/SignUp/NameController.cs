using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using BackEnd;

public class NameController : MonoBehaviour
{
    public TMP_InputField nicknameInput;
    public GameObject blankErrorMessage;
    public GameObject duplicateErrorMessage;
    public GameObject clearMessage;

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
                BackendLogin.Instance.UpdateNickname(nickname);
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

    public void ChangeNickname()
    {
        duplicateErrorMessage.SetActive(false);

        nickname = nicknameInput.GetComponent<TMP_InputField>().text;
        if (BlankCheck() == true) 
        {
            if (NickNameDuplicateCheck() == true)
            {
                Debug.Log(nickname);
                BackendLogin.Instance.UpdateNickname(nickname);
                clearMessage.transform.GetComponent<TMP_Text>().text = "Name Change Success!";
                clearMessage.SetActive(true);
            }
            else
            {
                duplicateErrorMessage.SetActive(true);
            }
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
            return false;
        }
    }

    private bool NickNameDuplicateCheck()
    {
        // 서버 연결
        BackendReturnObject bro = Backend.BMember.CheckNicknameDuplication(nickname);
        if (bro.IsSuccess())
        {
          Debug.Log("해당 닉네임은 중복되지 않습니다.");
          return true;
        }
        else
        {
          Debug.Log("해당 닉네임은 중복됩니다.");
          return false;
        }
    }

    private void ConfirmNickname()
    {
        Debug.Log("Confirm Name Button Clicked");
        nextSceneName = "HomeScene";
        FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
        // SceneManager.LoadScene(nextSceneName);
    }
}
