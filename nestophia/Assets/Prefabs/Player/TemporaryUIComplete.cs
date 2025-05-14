using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.Netcode.Transports.UTP;
#if NEW_INPUT_SYSTEM_INSTALLED
using UnityEngine.InputSystem.UI;
#endif

namespace Unity.Multiplayer.Center.NetcodeForGameObjectsExample
{
    /// <summary>
    /// A basic example of a UI to start a host or client.
    /// If you want to modify this Script please copy it into your own project and add it to your copied UI Prefab.
    /// </summary>
    public class TemporaryUIComplete : MonoBehaviour
    {
        [SerializeField]
        Button m_StartHostButton;
        [SerializeField]
        Button m_StartClientButton;

        [SerializeField]
        private string hostIpAddress = "192.168.0.111"; // 실제 호스트의 IP로 바꾸세요
        [SerializeField]
        private ushort hostPort = 7777;

        void Awake()
        {
            if (!FindAnyObjectByType<EventSystem>())
            {
                var inputType = typeof(StandaloneInputModule);
#if ENABLE_INPUT_SYSTEM && NEW_INPUT_SYSTEM_INSTALLED
                inputType = typeof(InputSystemUIInputModule);                
#endif
                var eventSystem = new GameObject("EventSystem", typeof(EventSystem), inputType);
                eventSystem.transform.SetParent(transform);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            m_StartHostButton.onClick.AddListener(StartHost);
            m_StartClientButton.onClick.AddListener(StartClient);
        }

        public void StartClient()
        {
            var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
            transport.SetConnectionData(hostIpAddress, hostPort);
            NetworkManager.Singleton.StartClient();
            // DeactivateButtons();
        }

        public void StartHost()
        {
            NetworkManager.Singleton.StartHost();
            // DeactivateButtons();
        }

        void DeactivateButtons()
        {
            m_StartHostButton.interactable = false;
            m_StartClientButton.interactable = false;
        }
    }
}