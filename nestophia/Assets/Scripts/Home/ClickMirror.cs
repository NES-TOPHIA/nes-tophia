using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ClickMirror : MonoBehaviour
{
    public InputActionProperty buttonAction;

    public Canvas customCanvas;

    void Start()
    {
        customCanvas.gameObject.SetActive(false);
    }

    void Update() 
    {
        //if (buttonAction.action.WasPressedThisFrame())
        //{
        //    Debug.Log("Primary Button Pressed");
        //    LoadClosetScene();
        //}

        if (OVRInput.GetUp(OVRInput.Button.Four))
        {
            Debug.Log("Mirror Pressed");
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("MirrorBtn"))
                {
                    Debug.Log("Mirror Clicked");
                    customCanvas.gameObject.SetActive(true);
                }
            }
        }
    }

    public void OpenCustomCanvas()
    {
        customCanvas.gameObject.SetActive(true);
    }

    //private void OnMouseDown() {
    //    LoadClosetScene();
    //}

    // public void LoadClosetScene() 
    // {
    //     Debug.Log("Closet Scene Loading...");
    //     nextSceneName = "ClosetScene";
    //     FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
    // }
}
