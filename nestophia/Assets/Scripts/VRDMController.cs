using UnityEngine;
using BackEnd;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class VRDMController : MonoBehaviour
{
    public GameObject chattingPanel;
    public GameObject friendButtonPrefab;
    public GameObject listContent;
    public TMP_InputField chatInputField;
    public GameObject receivedMessagePrefab;
    public GameObject chatContent;

    void Start()
    {
        UpdateFriendList();
    }
    
    public void UpdateFriendList()
    {
        BackendLogin.Instance.Login("4444", "1234");
        
        string[] friendList;
        friendList = BackendFriend.Instance.GetFriendList();
        /**
        foreach (string friend in friendList)
        {
            if (friend != null)
            {
                GameObject friendButton = Instantiate(friendButtonPrefab) as GameObject;
                friendButton.transform.SetParent(listContent.transform, false);
                friendButton.transform.GetComponentInChildren<TMP_Text>().text = friend;
            }
        }
        **/
    }

    public void ShowChattingWithClickedFriend()
    {
        //ShowReceivedMessage();
        chattingPanel.SetActive(true);
    }

    public void CloseChattingPanel()
    {
        chattingPanel.SetActive(!chattingPanel.activeSelf);
    }

    public void GetFriendsName()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        string friendName = clickObject.GetComponentInChildren<TMP_Text>().text;
        Debug.Log(friendName);
        PlayerPrefs.SetString("friendName", friendName);
    }

    public void SendChat()
    {
        string friendName = PlayerPrefs.GetString("friendName");
        Debug.Log(friendName);
        string userInDate = BackendChatting.Instance.GetUserInfoByName(friendName);
        string content = chatInputField.text;

        BackendChatting.Instance.SendChat(userInDate, content);
    }

    public void ShowReceivedMessage()
    {
        string[] receivedMessage = BackendChatting.Instance.GetReceivedChat();
        /**
        foreach (string message in receivedMessage)
        {
            if (message != null)
            {
                GameObject messageTab = Instantiate(receivedMessagePrefab) as GameObject;
                messageTab.transform.SetParent(chatContent.transform, false);
                messageTab.transform.GetComponentInChildren<TMP_Text>().text = message;
            }
        }
        
        for (int i = 0; i < 3; i++)
        {
            GameObject messageTab = Instantiate(receivedMessagePrefab) as GameObject;
            messageTab.transform.SetParent(chatContent.transform, false);
            if (i == 0)
                messageTab.transform.GetComponentInChildren<TMP_Text>().text = "hiiii how are u";
            else if (i == 1)
                messageTab.transform.GetComponentInChildren<TMP_Text>().text = "also, i'm good!!!";
            else
                messageTab.transform.GetComponentInChildren<TMP_Text>().text = ":)))";
        }
        **/
    }
}
