using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ClickMirror : MonoBehaviour
{
    public InputActionProperty buttonAction;

    private string nextSceneName;

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
            LoadClosetScene();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Btn"))
                {
                    Debug.Log("Mirror Clicked");
                    // LoadClosetScene();
                }
            }
        }
    }

    //private void OnMouseDown() {
    //    LoadClosetScene();
    //}

    public void LoadClosetScene() 
    {
        Debug.Log("Closet Scene Loading...");
        nextSceneName = "ClosetScene";
        FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
    }
}
