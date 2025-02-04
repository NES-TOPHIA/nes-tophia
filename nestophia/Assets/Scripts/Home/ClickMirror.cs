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
    }

    private void OnMouseDown() {
        LoadClosetScene();
    }

    public void LoadClosetScene() 
    {
        Debug.Log("Closet Scene Loading...");
        nextSceneName = "ClosetScene";
        FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
    }
}
