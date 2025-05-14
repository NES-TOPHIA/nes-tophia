using UnityEngine;
using UnityEngine.UI;

public class ImageClickHandler : MonoBehaviour
{
    private Image image;
    private MyFeedController feedController;

    void Awake()
    {
        image = GetComponent<Image>();
        feedController = FindObjectOfType<MyFeedController>();
    }

    public void OnClick()
    {
        if (image != null && feedController != null)
        {
            feedController.OnUIImageSelected(image.sprite);
        }
    }
}
