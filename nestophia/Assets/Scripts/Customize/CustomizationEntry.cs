using UnityEngine;

[CreateAssetMenu(fileName = "CustomizationEntry", menuName = "Character Customization/Entry")]
public class CustomizationEntry : ScriptableObject
{
    public string entryName; // 엔트리 이름
    public Sprite icon; // UI에서 표시할 이미지
    public GameObject prefab; // 적용할 프리팹
}
