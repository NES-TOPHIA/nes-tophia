using Unity.Netcode;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class GameManager : MonoBehaviour {
    void Start() {
        if (CheckIfFirstPlayer()) {
            NetworkManager.Singleton.StartHost();  // 첫 번째 사용자는 호스트
        } else {
            NetworkManager.Singleton.StartClient();  // 이후 사용자는 클라이언트
        }
    }

    bool CheckIfFirstPlayer() {
        // 현재 실행 중인 호스트가 있는지 확인
        return !NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer;
    }
}
