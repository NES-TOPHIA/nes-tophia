using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Management;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private Quaternion originalRotation; 
    private Quaternion hmdRotation = Quaternion.identity;

    [SerializeField] private float lookSensitivity = 2.0f;
    [SerializeField] private float cameraRotationLimit = 80f;
    private float currentCameraRotationX;

    [SerializeField] private Camera camera;
    private Rigidbody rigidbody;
    [SerializeField] private float zoomSpeed = 10.0f;

    private static PlayerMoveController instance;
    
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;

        // 씬이 변경될 때마다 위치, 속도 업데이트
        SceneManager.sceneLoaded += OnSceneLoaded;
        ApplySceneSettings(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplySceneSettings(scene.name);
    }

    private void ApplySceneSettings(string sceneName)
    {
        var settings = SceneData.Instance.GetSceneSettings(sceneName);
        transform.position = settings.position;
        moveSpeed = settings.speed;
    }

    void Update()
    {
        MovePlayer();
        HandleLookInput(); // 마우스 및 HMD 입력을 처리하여 회전 적용
        Zoom();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (context.control.device.displayName.Contains("Mouse"))
        {
            lookInput = context.ReadValue<Vector2>(); // ✅ 마우스 입력 처리
        }
        else
        {
            hmdRotation = context.ReadValue<Quaternion>(); // ✅ HMD 회전 처리
        }
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        Vector3 localMove = transform.TransformDirection(moveDirection);
        transform.position += localMove * moveSpeed * Time.deltaTime;
    }

    private void HandleLookInput()
    {
        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            float yRotation = hmdRotation.eulerAngles.y; // ✅ Yaw 값만 사용하여 플레이어 회전
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        else
        {
            // ✅ 마우스 입력으로 회전
            currentCameraRotationX -= lookInput.y * lookSensitivity;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
            camera.transform.localRotation = Quaternion.Euler(currentCameraRotationX, 0f, 0f);

            transform.Rotate(Vector3.up * lookInput.x * lookSensitivity);
        }
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
