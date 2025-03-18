using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class BackendChatting
{
    private static BackendChatting _instance = null;

    public static BackendChatting Instance
    {
        get{
            if (_instance == null)
            {
                _instance = new BackendChatting();
            }

            return _instance;
        }
    }

    public string GetUserInfoByName(string name)
    {
        string userName = name;

        var bro = Backend.Social.GetUserInfoByNickName(userName);

        //if (!bro.IsSuccess())
        //{
        //    return;
        //}

        LitJson.JsonData json = bro.GetReturnValuetoJSON();

        string userInDate = json["row"]["inDate"].ToString();

        Debug.Log("유저 정보 : " + userInDate);

        return userInDate;
    }

    public void SendChat(string inDate, string content)
    {
        Debug.Log("메시지 전송을 요청합니다.");

        var bro = Backend.Message.SendMessage(inDate, content);

        if (bro.IsSuccess())
        {
            Debug.Log("메시지 전송에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("메시지 전송에 실패했습니다. : " + bro);
        }
    }

    public string[] GetReceivedChat()
    {
        var bro = Backend.Message.GetReceivedMessageList();

        LitJson.JsonData json = bro.FlattenRows();

        string[] receivedMessageListString = new string[50];

        for (int i = 0; i < json.Count; i++)
        {
            receivedMessageListString[i] = json[i]["content"].ToString();
            //messageItem.inDate = json[i]["inDate"].ToString();

            //messageList.Add(messageItem);
        }
        Debug.Log(string.Join(", ", receivedMessageListString));

        return receivedMessageListString;
    }
}
