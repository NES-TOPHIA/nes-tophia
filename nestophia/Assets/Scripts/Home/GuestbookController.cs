using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using BackEnd;

public class GuestbookController : MonoBehaviour
{
    public GameObject guestBookPanel;
    public GameObject newComentPanel;

    public GameObject listContent;
    public GameObject postPanel;

    private GameObject player;
    private string contentText;
    private GameObject addPost;
    private string name;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.Four))
        {
            Debug.Log("Laptop Pressed");
            OpenGuestBook();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Laptop"))
                {
                    Debug.Log("Laptop Pressed");
                    OpenGuestBook();
                }
            }
        }
    }

    private void OnMouseDown() 
    {
        Debug.Log("Laptop Pressed");
        OpenGuestBook();
    }

    public void OpenGuestBook()
    {
        guestBookPanel.SetActive(true);
    }

    public void SavePost()
    {
        DeliverWriting();
        newComentPanel.SetActive(false);
    }
    
    // 여기부터 다시 수정
    private void DeliverWriting()
    {
        name = Backend.UserNickName;
        GameObject post = Instantiate(postPanel) as GameObject;
        post.transform.SetParent(listContent.transform, false);

        contentText = newComentPanel.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TMP_Text>().text;
        post.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = contentText;

        post.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = name;
        
        ResetContent();
    }

    public void ResetContent()
    {
        newComentPanel.transform.GetChild(1).GetComponent<TMP_InputField>().text = "";
    }
}
