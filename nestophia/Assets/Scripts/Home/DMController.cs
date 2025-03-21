using UnityEngine;
using BackEnd;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class DMController : MonoBehaviour
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
        // BackendLogin.Instance.Login("4444", "1234");
        
        string[] friendList;
        friendList = BackendFriend.Instance.GetFriendList();
        foreach (string friend in friendList)
        {
            if (friend != null)
            {
                GameObject friendButton = Instantiate(friendButtonPrefab) as GameObject;
                friendButton.transform.SetParent(listContent.transform, false);
                friendButton.transform.GetComponentInChildren<TMP_Text>().text = friend;
            }
        }
    }

    public void ShowChattingWithClickedFriend()
    {
        chattingPanel.SetActive(true);
        ShowReceivedMessage();
    }

    public void CloseChattingPanel()
    {
        chattingPanel.SetActive(false);
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
        foreach (string message in receivedMessage)
        {
            if (message != null)
            {
                GameObject messageTab = Instantiate(receivedMessagePrefab) as GameObject;
                messageTab.transform.SetParent(chatContent.transform, false);
                messageTab.transform.GetComponentInChildren<TMP_Text>().text = message;
            }
        }
    }
}