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

    //public void ReceiveChat
}
