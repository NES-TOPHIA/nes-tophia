using UnityEngine;

public class PlayerCameraHandler : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 기존 MainCamera 태그를 가진 카메라가 있다면 태그 제거
        Camera[] allCameras = GameObject.FindObjectsOfType<Camera>();
        foreach (Camera cam in allCameras)
        {
            if (cam.CompareTag("MainCamera") && cam != playerCamera)
            {
                cam.tag = "Untagged";
            }
        }

        // 내 카메라를 MainCamera로 지정
        playerCamera.tag = "MainCamera";
        
    }
}
