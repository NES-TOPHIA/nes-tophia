using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.IO;


public class PhotoCaptureController : MonoBehaviour
{
    private bool isPressed;

   [Header("카메라와 렌더 텍스처 설정")]
    public Camera captureCamera;                    // 오브젝트를 비추는 카메라 (거울 + 캡처 둘 다 담당)
    public RenderTexture mirrorRenderTexture;       // 평상시 거울 기능용 RenderTexture
    public RenderTexture captureRenderTexture;      // 사진 촬영용 RenderTexture

    [Header("저장 파일 설정")]
    public string baseFileName = "CapturedObject";  // 저장할 파일명

    void Start()
    {
        isPressed = false;
        
    } 

    void Update()
    {
        if(isPressed)
        {
            CaptureObject();
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
        string folderPath = Application.persistentDataPath;
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
}


       