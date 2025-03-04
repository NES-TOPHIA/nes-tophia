using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    public Transform characterModel; // 커스터마이징할 캐릭터
    public GameObject basicCharacter;
    public List<CustomizationEntry> customizationEntries; // 엔트리 목록
    private GameObject currentCustomization; // 현재 적용된 프리팹
    private bool isBasicCharacterRemoved = false; // 기본 캐릭터 삭제 여부 플래그

    public void ApplyCustomization(int index)
    {
        if (index < 0 || index >= customizationEntries.Count) return;

        if (!isBasicCharacterRemoved && basicCharacter != null)
        {
            Destroy(basicCharacter);
            isBasicCharacterRemoved = true;
        }
        //기존의 커스터마이징 항목 제거
        if (currentCustomization != null)
        {
            
            Destroy(currentCustomization); 
            
        }

        // 새로운 프리팹 적용
        if (customizationEntries[index].prefab != null)
        {
            currentCustomization = Instantiate(customizationEntries[index].prefab, characterModel);
        }
    }
}
