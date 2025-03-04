using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class MyFeedController : MonoBehaviour
{
    public GameObject myFeedPanel;
    public GameObject newPostPanel;

    public InputActionProperty buttonAction;
    public GameObject listContent;
    public GameObject postPanel;

    private GameObject player;
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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Book"))
                {
                    Debug.Log("Book Pressed");
                    OpenMyFeedPanel();
                }
            }
        }
    }

    private void OnMouseDown() 
    {
        Debug.Log("Book Pressed");
        OpenMyFeedPanel();
    }

    public void OpenMyFeedPanel()
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

        contentText = newPostPanel.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text;
        post.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = contentText;
        
        ResetContent();
    }

    public void ResetContent()
    {
        newPostPanel.transform.GetChild(1).GetComponent<TMP_InputField>().text = "";
    }
}
