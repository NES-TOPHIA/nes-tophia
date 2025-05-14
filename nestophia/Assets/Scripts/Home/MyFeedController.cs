using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using BackEnd;

public class MyFeedController : MonoBehaviour
{
    public GameObject framePrefab;
    public GameObject wall;
    public int columnCount = 4;        // 한 줄에 몇 개?
    public float spacing = 0.2f;       // 프레임 간 간격 
    public Vector3 startPosition = new Vector3(-0.3f, 0.1f, -0.02f); // 벽 위에서 시작 위치
    public Vector2 frameSize = new Vector2(1.2f, 0.9f); // 프레임 크기 설정

    private int currentCount = 0;      // 지금까지 생성된 프레임 수

    private GameObject image;
    private Sprite imageSprite;

    void Update() 
    {
        if (OVRInput.GetUp(OVRInput.Button.Four))
        {
            //Debug.Log("Book Pressed");
            //OpenMyFeedPanel();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Image"))
                {
                    Debug.Log("Image Pressed");
                    image = EventSystem.current.currentSelectedGameObject;
                    //imageSprite = GetImageSprite(image);
                }
            }
        }
    }

    

    public void ClickImage()
    {
        imageSprite = GetImageSprite(image);
        if (imageSprite != null)
        {
            Debug.Log("스프라이트 추출 성공");
            MakeFrameImage(imageSprite);
        }
    }

    public Sprite GetImageSprite(GameObject image)
    {
        Sprite selectedSprite = null;
        SpriteRenderer spriteRenderer = image.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            selectedSprite = spriteRenderer.sprite;
        }

        return selectedSprite;
    }

    public void OnUIImageSelected(Sprite selectedSprite)
    {
        if (selectedSprite != null)
        {
            Debug.Log("UI 이미지 선택됨");
            MakeFrameImage(selectedSprite);
        }
    }

    public void MakeFrameImage(Sprite selectedSprite) 
    {
        GameObject frame = Instantiate(framePrefab, wall.transform);

        // 위치 계산
        int row = currentCount / columnCount;
        int col = currentCount % columnCount;

        Vector3 offset = new Vector3(col * spacing, -row * spacing, 0); // Y 축은 위에서 아래로 정렬
        frame.transform.localPosition = startPosition + offset;

        GameObject frameImage = frame.transform.GetChild(0).gameObject;
        SpriteRenderer spriteRenderer = frameImage.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && selectedSprite != null)
        {
            spriteRenderer.sprite = selectedSprite;
            // 스프라이트 크기 강제 조절
            frameImage.transform.localScale = new Vector3(
                frameSize.x / selectedSprite.bounds.size.x,
                frameSize.y / selectedSprite.bounds.size.y,
                1
            );
        }

        currentCount++; // 다음 위치를 위해 증가
    }
}