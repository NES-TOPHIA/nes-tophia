using UnityEngine;
using TMPro;

public class BuildingEvolutionController : MonoBehaviour
{
    public TMP_Text friendsCountText;
    private int friendsCount = 0;

    public GameObject[] buildings;  


    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        UpdateBuildingAppearance();
    }

    void UpdateUI()
    {
        friendsCountText.text = friendsCount.ToString();
        UpdateBuildingAppearance();
    }

    public void AddFriend()
    {
        friendsCount++;
        UpdateUI();
    }

    void UpdateBuildingAppearance()
    {
        int buildingIndex = 0;

        if (friendsCount >= 10)
            buildingIndex = 2;  // 아파트
        else if (friendsCount >= 5)
            buildingIndex = 1;  // 빌라
        else
            buildingIndex = 0;  // 주택

        // 모든 건물 비활성화 후 해당 건물만 활성화
        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i].SetActive(i == buildingIndex);
        }
    }
}
