using Unity.Netcode;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using TMPro;

public class VRButtonManager : MonoBehaviour
{
    public Canvas searchCanvas;
    public TextMeshProUGUI logText1;
    public TextMeshProUGUI logText2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void OpenCanvas()
    {
        searchCanvas.gameObject.SetActive(true);
    }

    public void CloseCanvas()
    {
        searchCanvas.gameObject.SetActive(false);
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost(); 
        logText1.text = "Start Host";
        logText2.text = "Start Host";
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        logText1.text = "StartClient";
        logText2.text = "StartClient";
    }
}
