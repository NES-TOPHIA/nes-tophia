using UnityEngine;
using BackEnd;
using TMPro;
using UnityEngine.InputSystem;

public class DMController : MonoBehaviour
{
    public GameObject chattingPanel;
    public TMP_InputField chatInputField;

    public void ShowChattingWithClickedFriend()
    {
        chattingPanel.SetActive(true);
    }

    public void CloseChattingPanel()
    {
        chattingPanel.SetActive(false);
    }

    public void SendChat()
    {
        string content = chatInputField.text;
        var bro = Backend.Message.SendMessage("minju", content);

        if (bro.IsSuccess())
        {
            Debug.Log("메시지 전송에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("메시지 전송에 실패했습니다. : " + bro);
        }
    }
}