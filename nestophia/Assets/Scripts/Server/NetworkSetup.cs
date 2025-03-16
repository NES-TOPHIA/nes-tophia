using Unity.Netcode;
using UnityEngine;
using System.Linq;

public class NetworkSetup : MonoBehaviour
{
    void Start()
    {
        if (IsServerMode())
        {
            NetworkManager.Singleton.StartServer();
        }
        else
        {
            NetworkManager.Singleton.StartClient();
        }
    }

    bool IsServerMode()
    {
        return System.Environment.GetCommandLineArgs().Contains("-server");
    }
}
