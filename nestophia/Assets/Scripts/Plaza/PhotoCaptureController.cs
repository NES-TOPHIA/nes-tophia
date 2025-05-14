using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class PhotoCaptureController : MonoBehaviour
{
    private bool isPressed;

   [Header("카메라와 렌더 텍스처 설정")]
   [SerializeField] private Camera captureCamera;                    // 오브젝트를 비추는 카메라 (거울 + 캡처 둘 다 담당)
    [SerializeField] private RenderTexture mirrorRenderTexture;       // 평상시 거울 기능용 RenderTexture
    [SerializeField] private RenderTexture captureRenderTexture;      // 사진 촬영용 RenderTexture

    [Header("저장 파일 설정")]
    [SerializeField] private string baseFileName = "CapturedObject";  // 저장할 파일명

    private PlayerInput playerInput;

    [SerializeField] private GameObject blindPlane;



    void Start()
    {
        isPressed = false;
        blindPlane.SetActive(false);

        // 씬 로드 이벤트 연결
        SceneManager.sceneLoaded += OnSceneLoaded;

        // 혹시 이미 VRPlaza 씬이라면 바로 실행
        if (SceneManager.GetActiveScene().name == "VRPlaza")
        {
            TryBindToPlayerInput();
        }
    }

    void OnDestroy()
    {
        // 이벤트 구독 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // 리스너 해제 (메모리 누수 방지)
        UnbindFromPlayerInput();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "VRPlaza")
        {
            TryBindToPlayerInput();
        }
        else
        {
            UnbindFromPlayerInput();
        }
    }

    void TryBindToPlayerInput()
    {
        // Player 오브젝트 찾아서 PlayerInput 얻기
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            playerInput = playerObj.GetComponent<PlayerInput>();
            if (playerInput != null)
            {
                Debug.Log("PlayerInput Click에 PhotoCaptureController.OnClick 연결");
                playerInput.actions["Click"].performed -= OnClick;  // 중복 제거
                playerInput.actions["Click"].performed += OnClick;
            }
        }
    }

    void UnbindFromPlayerInput()
    {
        if (playerInput != null)
        {
            Debug.Log("PlayerInput Click에서 PhotoCaptureController.OnClick 해제");
            playerInput.actions["Click"].performed -= OnClick;
            playerInput = null;
        }
    }

    void Update()
    {
        if(isPressed)
        {
            CaptureObject();
            StartCoroutine(ShowBlindPanelForSeconds(0.7f)); 
            isPressed = false;
        }

    }

    public void OnShotterButtonPress()
    {
        if(!isPressed)
        {
            isPressed = true;
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed && !isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("ShotterBtn"))
                {
                    Debug.Log("ShotterBtn Pressed");
                    isPressed = true;
                }
            }
        }
    }

    public void CaptureObject()
    {
        //현재 활성화된 RenderTexture 백업 (GPU의 상태)
        RenderTexture currentRT = RenderTexture.active;
    
        //카메라의 원래 targetTexture 백업 (거울용 RenderTexture)
        RenderTexture originalTargetTexture = captureCamera.targetTexture;
    
        //캡처용 RenderTexture로 전환
        RenderTexture.active = captureRenderTexture;
        captureCamera.targetTexture = captureRenderTexture;
    
        //렌더링
        captureCamera.Render();
    
        //픽셀 데이터 복사
        Texture2D image = new Texture2D(captureRenderTexture.width, captureRenderTexture.height, TextureFormat.RGB24, false);
        image.ReadPixels(new Rect(0, 0, captureRenderTexture.width, captureRenderTexture.height), 0, 0);
        image.Apply();
    
        //파일 경로 자동 생성 (중복 방지)

        string folderPath = Path.Combine(Application.persistentDataPath, "ScreenShot");
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string extension = ".png";
        string filePath = Path.Combine(folderPath, baseFileName + extension);
        int counter = 1;
        while (File.Exists(filePath))
        {
            filePath = Path.Combine(folderPath, baseFileName + "_" + counter + extension);
            counter++;
        }

        //PNG로 저장
        byte[] bytes = image.EncodeToPNG();
        File.WriteAllBytes(filePath, bytes);
        Debug.Log("Saved image to: " + filePath);
    
        //상태 원상복구
        captureCamera.targetTexture = originalTargetTexture;   // 거울 기능용 RenderTexture로 복구
        RenderTexture.active = currentRT;                      // GPU 상태 복구
        Destroy(image);


    }
    private IEnumerator ShowBlindPanelForSeconds(float seconds)
    {
        blindPlane.SetActive(true);
        yield return new WaitForSeconds(seconds);
        blindPlane.SetActive(false);
    }
}


       