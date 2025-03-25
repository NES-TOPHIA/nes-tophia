using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class FriendsManager : MonoBehaviour
{
    [SerializeField] private Canvas playerNameCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerNameCanvas.gameObject.SetActive(false);
        
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("Friends"))
                {
                    playerNameCanvas.gameObject.SetActive(true);
                    Debug.Log("activate friendsName");
                }
            }
        }
    }

    public void OpenPlayerNameCanvas()
    {
        playerNameCanvas.gameObject.SetActive(true);
    }
}
