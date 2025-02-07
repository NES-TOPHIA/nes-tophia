using UnityEngine;

public class DMController : MonoBehaviour
{
    public GameObject chattingPanel;

    public void ShowChattingWithClickedFriend()
    {
        chattingPanel.SetActive(true);
    }

    public void CloseChattingPanel()
    {
        chattingPanel.SetActive(false);
    }
}