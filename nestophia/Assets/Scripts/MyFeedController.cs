using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class MyFeedController : MonoBehaviour
{
    public GameObject myFeedPanel;
    public InputActionProperty buttonAction;

    private GameObject newPostPanel;
    private GameObject listContent;
    private GameObject postPanel;
    private GameObject player;
    private string titleText;
    private string contentText;
    private GameObject addPost;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update() 
    {
//        if (buttonAction.action.WasPressedThisFrame())
//        {
//            Debug.Log("Primary Button Pressed");
//            OpenMyFeedPanel();
//        }

        if (OVRInput.GetUp(OVRInput.Button.Four))
        {
            Debug.Log("Book Pressed");
            OpenMyFeedPanel();
        }
    }

    private void OpenMyFeedPanel()
    {
        myFeedPanel.SetActive(true);
    }

    public void SavePost()
    {
        DeliverWriting();
        newPostPanel.SetActive(false);
    }
    
    private void DeliverWriting()
    {
        GameObject post = Instantiate(postPanel) as GameObject;
        post.transform.SetParent(listContent.transform, false);

        titleText = newPostPanel.transform.GetChild(3).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text;
        post.transform.GetChild(2).GetComponent<TMP_Text>().text = titleText;

        contentText = newPostPanel.transform.GetChild(4).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text;
        post.transform.GetChild(3).GetComponent<TMP_Text>().text = contentText;

        newPostPanel.transform.GetChild(3).GetComponent<TMP_InputField>().text = "";
        newPostPanel.transform.GetChild(4).GetComponent<TMP_InputField>().text = "";
    }
}
