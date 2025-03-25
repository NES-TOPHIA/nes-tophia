using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class BackendLogin
{
    private static BackendLogin _instance = null;

    public static BackendLogin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendLogin();
            }

            return _instance;
        }
    }

    public bool SignUp(string id, string pw)
    {
        Debug.Log("회원 가입을 요청합니다.");
        
        var bro = Backend.BMember.CustomSignUp(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("회원 가입에 성공했습니다. : " + bro);
            return true;
        }
        else
        {
            if (bro.GetStatusCode() != "400")
            {
                Debug.LogError("회원 가입에 실패했습니다. : " + bro);
                return false;
            }
            else {
                return true;
            }
            
        }
    }

    public bool Login(string id, string pw)
    {
        Debug.Log("로그인을 요청합니다.");

        var bro = Backend.BMember.CustomLogin(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("로그인이 성공했습니다. : " + bro);
            return true;
        }
        else
        {
            if (bro.GetStatusCode() != "400")
            {
                Debug.LogError("로그인이 실패했습니다. : " + bro);
                return false;
            }
            else {
                return true;
            }
        }
    }

    public void UpdateNickname(string nickname)
    {
        Debug.Log("닉네임 변경을 요청합니다.");

        var bro = Backend.BMember.UpdateNickname(nickname);

        if (bro.IsSuccess())
        {
            Debug.Log("닉네임 변경에 성공했습니다 : " + bro);
        }
        else
        {
            Debug.LogError("닉네임 변경에 실패했습니다 : " + bro);
        }
    }
}
