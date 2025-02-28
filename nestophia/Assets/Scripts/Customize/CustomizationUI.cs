using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro 네임스페이스 추가

public class CustomizationUI : MonoBehaviour
{
    public CustomizationManager customizationManager;
    public Transform buttonContainer; // 버튼이 추가될 UI 부모 오브젝트
    public Button buttonPrefab; // UI 버튼 프리팹

    void Start()
    {
        for (int i = 0; i < customizationManager.customizationEntries.Count; i++)
        {
            int index = i;
            Button newButton = Instantiate(buttonPrefab, buttonContainer);

            // TMP_Text로 변경
            TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = customizationManager.customizationEntries[i].entryName;
            }
            else
            {
                Debug.LogWarning("TMP_Text 컴포넌트를 찾을 수 없습니다.");
            }

            newButton.GetComponent<Image>().sprite = customizationManager.customizationEntries[i].icon;
            newButton.onClick.AddListener(() => customizationManager.ApplyCustomization(index));
        }
    }
}
