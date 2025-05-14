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

    public void ActiveGallery()
    {
        LoadImages();
    }
    
    public void LoadImages() 
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


    /**
    // 이미지 배열
    public GameObject[] images;

    // 여러 프레임 그룹을 담는 배열 (2차원 배열 형태)
    public GameObject[][] frameGroups;

    // 각각의 프레임 그룹을 인스펙터에서 연결할 수 있도록 public 배열로 선언
    public GameObject[] imageFrames;
    public GameObject[] imageFrames2;
    public GameObject[] imageFrames3;
    public GameObject[] imageFrames4;

    private int currentIndex = 0;

    void Start()
    {
        // Start에서 2차원 배열 초기화
        frameGroups = new GameObject[][]
        {
            imageFrames,
            imageFrames2,
            imageFrames3,
            imageFrames4
        };

        ShowImage(currentIndex);
    }

    void ShowImage(int index)
    {
        // 모든 이미지 비활성화
        foreach (GameObject image in images)
        {
            image.SetActive(false);
        }
        images[index].SetActive(true);

        // 각 프레임 그룹별로 처리
        foreach (GameObject[] group in frameGroups)
        {
            for (int i = 0; i < group.Length; i++)
            {
                group[i].SetActive(i == index);  // 현재 인덱스만 활성화
            }
        }
    }

    public void NextImage()
    {
        currentIndex = (currentIndex + 1) % images.Length;
        ShowImage(currentIndex);
    }

    public void PreviousImage()
    {
        currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        ShowImage(currentIndex);
    }
    **/


}