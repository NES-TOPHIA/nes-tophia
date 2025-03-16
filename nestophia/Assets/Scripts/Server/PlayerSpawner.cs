using Unity.Netcode;
using UnityEngine;

public class PlayerSpawner : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            var player = Instantiate(Resources.Load<GameObject>("PlayerPrefab"));
            player.GetComponent<NetworkObject>().Spawn();
        }
    }
}
