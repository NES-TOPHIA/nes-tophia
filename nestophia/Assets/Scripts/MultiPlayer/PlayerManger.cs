using Unity.Netcode;
using UnityEngine;

public class PlayerManager : NetworkBehaviour {
    public GameObject playerPrefab;

    public override void OnNetworkSpawn() {
        if (IsClient && IsOwner) {  
            RequestSpawnPlayerServerRpc();
        }
    }

    [ServerRpc]
    void RequestSpawnPlayerServerRpc(ServerRpcParams rpcParams = default) {
        if (!IsServer) return; // 서버에서만 실행

        GameObject player = Instantiate(playerPrefab);
        player.GetComponent<NetworkObject>().SpawnAsPlayerObject(rpcParams.Receive.SenderClientId);
    }
}
