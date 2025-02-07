using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ClickCarpet : MonoBehaviour
{
    public InputActionProperty buttonAction;

    private string nextSceneName;

    void Update() 
    {
        //if (buttonAction.action.WasPressedThisFrame())
        //{
        //    Debug.Log("Primary Button Pressed");
        //    LoadFurnitureScene();
        //}

        if (OVRInput.GetUp(OVRInput.Button.Four))
        {
            Debug.Log("Carpet Pressed");
            LoadFurnitureScene();
        }
    }

    private void OnMouseDown() {
        LoadFurnitureScene();
    }

    public void LoadFurnitureScene() 
    {
        Debug.Log("Furniture Scene Loading...");
        nextSceneName = "FurnitureScene";
        // FindObjectOfType<SceneEffect>().FadeToScene(nextSceneName);
        SceneManager.LoadScene(nextSceneName);
    }
}
