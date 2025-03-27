using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorController : MonoBehaviour
{
    // SceneEffect_Simple sceneEffect;
    public GameObject[] floors;
    public GameObject[] numbers;

    void Start()
    {
        InitilizeFloors();
        // sceneEffect = FindObjectOfType<SceneEffect_Simple>();
    }

    // Start is called before the first frame update
    void InitilizeFloors()
    {
        for(int i = 0; i < floors.Length; i++)
        {
            floors[i].SetActive(false);
            Debug.Log(floors[i]);
        }
        floors[1].SetActive(true);
    }

     public void ClickFloor(int newIndex)
    {
        for(int i = 0; i < floors.Length; i++)
        {
            floors[i].SetActive(false);
        }
        floors[newIndex].SetActive(true);
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("No.1"))
                {
                    ClickFloor(1);
                    if(SceneManager.GetActiveScene().name == "Elevator")
                    {
                        FindObjectOfType<VRSceneEffect>().FadeToScene("HomeScene");
                    }
                    else if(SceneManager.GetActiveScene().name == "VRElevator")
                    {
                        Debug.Log("Go HomeScene");
                        FindObjectOfType<VRSceneEffect>().FadeToScene("VRHomeScene");
                    }
                }
                if(hit.collider.gameObject.CompareTag("No.2"))
                {
                    ClickFloor(2);
                }
                if(hit.collider.gameObject.CompareTag("No.3"))
                {
                    ClickFloor(3);
                }
                if(hit.collider.gameObject.CompareTag("No.4"))
                {
                    ClickFloor(4);
                }
                if(hit.collider.gameObject.CompareTag("No.5"))
                {
                    ClickFloor(5);
                }
                if(hit.collider.gameObject.CompareTag("No.6"))
                {
                    ClickFloor(6);
                }
                if(hit.collider.gameObject.CompareTag("No.7"))
                {
                    ClickFloor(7);
                }
                if(hit.collider.gameObject.CompareTag("No.8"))
                {
                    ClickFloor(8);
                }
                if(hit.collider.gameObject.CompareTag("No.9"))
                {
                    ClickFloor(9);
                }
                if(hit.collider.gameObject.CompareTag("BellBtn"))
                {
                    ClickFloor(0);
                    if(SceneManager.GetActiveScene().name == "Elevator")
                    {
                        FindObjectOfType<VRSceneEffect>().FadeToScene("Plaza");
                    }
                    else if(SceneManager.GetActiveScene().name == "VRElevator")
                    {
                        Debug.Log("Go PlazaScene");
                        FindObjectOfType<VRSceneEffect>().FadeToScene("VRPlaza");
                    }
                }
            }
        }   
    }

    public void GoHomeScene()
    {
        FindObjectOfType<VRSceneEffect>().FadeToScene("HomeScene");
    }

    public void GoVRHomeScene()
    {
        FindObjectOfType<VRSceneEffect>().FadeToScene("VRHomeScene");
    }

    public void GoPlazaScene()
    {
        FindObjectOfType<VRSceneEffect>().FadeToScene("Plaza");
    }

    public void GoVRPlazaScene()
    {
        FindObjectOfType<VRSceneEffect>().FadeToScene("VRPlaza");
    }


}