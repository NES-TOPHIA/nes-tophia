using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class GalleryController : MonoBehaviour
{
    public GameObject galleryPanel;
    public RectTransform imageContent;
    public GameObject imagePrefab;

    private string galleryPath = "/ScreenShot";

    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.Four))
        {
            Debug.Log("Frame Pressed");
            ActiveGallery();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Frame"))
                {
                    Debug.Log("Frame Pressed");
                    ActiveGallery();
                    OpenGallery();
                }
            }
        }
    }

    private void OnMouseDown() 
    {
        
    }

    public void ActiveGallery()
    {
        LoadImages();
    }

    public void OpenGallery()
    {
        galleryPanel.SetActive(!galleryPanel.activeSelf);
    }

    private void LoadImages() 
    {
        // 지정된 경로에서 이미지를 불러오기
        string fullPath = Application.persistentDataPath + galleryPath;
        
        if (!Directory.Exists(fullPath))
        {
            Debug.Log("갤러리 생성" + fullPath);
            Directory.CreateDirectory(fullPath);
        }

        Debug.Log("갤러리 로딩 성공" + fullPath);

        string[] imagePaths = Directory.GetFiles(fullPath, "*.png");

        foreach (Transform child in imageContent)
        {
            Destroy(child.gameObject);
        }


        foreach (string imagePath in imagePaths)
        {

            byte[] fileData = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            if (texture.LoadImage(fileData))
            {
                // 텍스처 → 스프라이트 변환
                Sprite sprite = Sprite.Create(
                    texture, 
                    new Rect(0, 0, texture.width, texture.height), 
                    new Vector2(0.5f, 0.5f)
                );

                // 프리팹 인스턴스화
                GameObject imageObject = Instantiate(imagePrefab, imageContent);
                Image uiImage = imageObject.GetComponent<Image>();
                uiImage.sprite = sprite;

                Debug.Log("이미지 로딩 성공");
            }
            else
            {
                Debug.LogWarning("이미지 로딩 실패: " + imagePath);
            }

            /**
            // 각 이미지마다 새로운 GameObject를 생성
            GameObject imageObject = new GameObject("Image");
            imageObject.transform.SetParent(imageContent.transform);

            // 파일에서 텍스처를 불러오기
            byte[] fileData = System.IO.File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            // 텍스처로부터 스프라이트를 생성
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            // GameObject에 SpriteRenderer 컴포넌트를 추가하고 스프라이트를 할당
            SpriteRenderer spriteRenderer = imageObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            **/
        }
    }
}
