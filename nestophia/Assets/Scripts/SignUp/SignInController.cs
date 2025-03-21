using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using BackEnd;
using UnityEngine.SceneManagement;

public class SignInController : MonoBehaviour
{
    public TMP_InputField IDInput;
    public TMP_InputField PWInput;
    public GameObject errorMessage;

    private string ID;
    private string PW;
    private string nextSceneName;

    public void SignIn()
    {
        errorMessage.SetActive(false);
        ID = IDInput.GetComponent<TMP_InputField>().text;
        PW = PWInput.GetComponent<TMP_InputField>().text;

        if (BackendLogin.Instance.Login(ID, PW) == true)
        {
            SuccessLogin();
        }
        else
        {
            errorMessage.SetActive(true);
        }
    }

    private void SuccessLogin()
    {
        string name = Backend.UserNickName;
        Debug.Log(name);

        nextSceneName = "HomeScene";
        FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
    }
}
