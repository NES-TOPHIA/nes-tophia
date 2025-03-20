using UnityEngine;


public class VRButtonManager : MonoBehaviour
{
    public Canvas searchCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OpenCanvas()
    {
        searchCanvas.gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        searchCanvas.gameObject.SetActive(false);
    }
}
