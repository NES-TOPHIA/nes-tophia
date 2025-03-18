using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR.Management;



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

    private static PlayerMoveController instance;
    private bool isVRActive = false;

     // VR 조이스틱 입력

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

        // 씬이 변경될 때마다 위치, 속도 업데이트
        SceneManager.sceneLoaded += OnSceneLoaded;
        ApplySceneSettings(SceneManager.GetActiveScene().name);

        isVRActive = XRGeneralSettings.Instance.Manager.activeLoader != null;
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
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        Vector3 localMove = transform.TransformDirection(moveDirection);
        transform.position += localMove * moveSpeed * Time.deltaTime;
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
