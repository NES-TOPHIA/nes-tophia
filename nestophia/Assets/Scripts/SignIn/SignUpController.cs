using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
//using BackEnd;

public class SignUpController : MonoBehaviour
{
    public TMP_InputField IDInput;
    public TMP_InputField PWInput;
    public GameObject signInPanel;
    public GameObject duplicateErrorMessage;

    private string ID;
    private string PW;

    public void SetID()
    {
        duplicateErrorMessage.SetActive(false);
        ID = IDInput.GetComponent<TMP_InputField>().text;
        PW = PWInput.GetComponent<TMP_InputField>().text;

        if (BlankCheck() == true) 
        {
            if (IDDuplicateCheck() == true)
            {
                Debug.Log(ID);
                ConfirmID();
            }
            else
            {
                duplicateErrorMessage.SetActive(true);
            }
        }
    }

    private bool IDDuplicateCheck()
    {
        // 서버 연결
        // return BackendLogin.Instance.SignUp(ID, PW);
        return true;
    }

    private bool BlankCheck()
    {
        if ((ID != "") && (PW != ""))
        {
            return true;
        } 
        else
        {
            return false;
        }
    }

    private void ConfirmID()
    {
        Debug.Log("Sign Up Success");
        signInPanel.SetActive(false);
    }
}
