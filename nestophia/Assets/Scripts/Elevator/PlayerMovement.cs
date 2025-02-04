using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f; 
    private Vector2 moveInput;

    [SerializeField] private float lookSensitivity = 2.0f;
    [SerializeField] private float cameraRotationLimit = 80f;  
    private float currentCameraRotationX;  

    [SerializeField] private Camera camera; 
    private Rigidbody rigidbody;
    [SerializeField] private float zoomSpeed = 10.0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); // Rigidbody 초기화
        Cursor.lockState = CursorLockMode.Locked; // 마우스 고정
        Cursor.visible = false;
    }

    void Update()
    {
        MovePlayer();
        CameraRotation();
        PlayerRotation();
        Zoom();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); 
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(-moveInput.y, 0, moveInput.x); // 기존 이동 방향
        Vector3 localMove = transform.TransformDirection(moveDirection); // 플레이어 회전에 맞게 변환

        Vector3 newPosition = transform.position + localMove * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void CameraRotation()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y") * lookSensitivity;
        currentCameraRotationX -= xRotation;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
    
        camera.transform.localRotation = Quaternion.Euler(currentCameraRotationX, 0f, 0f);
    }

    private void PlayerRotation()
    {
        float yRotation = Input.GetAxisRaw("Mouse X") * lookSensitivity;
        transform.Rotate(Vector3.up, yRotation);
    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        if (distance != 0)
        {
            camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - distance, 30f, 70f);
        }
    }
}
