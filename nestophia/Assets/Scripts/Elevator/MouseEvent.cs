using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    // Vector3 destination = new Vector3(-1.5f, -3f, -9f);
    // Vector3 currentPosition;
    // Vector3 originScale;
    [SerializeField]
    private GameObject otherFeed;
    [SerializeField]
    private GameObject otherFeedVR;
    void Start()
    {
        otherFeed.gameObject.SetActive(false);
        otherFeedVR.gameObject.SetActive(false);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && gameObject.tag == "Feed")
        {    
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))  
            {
                if(hit.collider.gameObject.CompareTag("Feed"))
                {
                    otherFeed.gameObject.SetActive(true);
                        // transform.position = Vector3.MoveTowards(transform.position, destination, 1);
                        // transform.localScale = new Vector3(0f, 2f, 2f);
                        // click = false;
                }
            }
            
        }
    }
    public void OpenFeed()
    {
        otherFeedVR.gameObject.SetActive(true);
    }
    public void HideFeed()
    {
        otherFeed.gameObject.SetActive(false);
    }

    public void HideFeedVR()
    {
        otherFeedVR.gameObject.SetActive(false);
    }
    // void resetAnim()
    // {
    //     transform.position = Vector3.MoveTowards(transform.position, currentPosition, 1);
    //     transform.localScale = originScale;
       
    // }
}

