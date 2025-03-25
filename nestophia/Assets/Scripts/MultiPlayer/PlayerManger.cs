using Unity.Netcode;
using UnityEngine;

public class PlayerManager : NetworkBehaviour {
    public GameObject playerPrefab;

    public override void OnNetworkSpawn() {
        if (IsServer) {
            SpawnPlayer();
        }
    }

    void SpawnPlayer() {
        GameObject player = Instantiate(playerPrefab);
        player.GetComponent<NetworkObject>().Spawn();
    }
}
