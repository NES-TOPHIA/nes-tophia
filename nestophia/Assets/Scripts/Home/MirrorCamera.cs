using UnityEngine;

public class MirrorCamera : MonoBehaviour
{
    public Transform player;
    public Transform mirror;

    void Update()
    {
        Vector3 localPlayer = mirror.InverseTransformPoint(player.position);
        transform.position = mirror.TransformPoint(new Vector3(localPlayer.x, localPlayer.y, -localPlayer.z));
 
 
        Vector3 localMirror = mirror.TransformPoint(new Vector3(-localPlayer.x, localPlayer.y, localPlayer.z));
        transform.LookAt(localMirror);
    }
}
