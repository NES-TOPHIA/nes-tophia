using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BuildingEvolutionController : MonoBehaviour
{
    public GameObject[] buildings; 
    [SerializeField]
    public FriendsCountManager friendsCountManager;

    void Update()
    {
        friendsCountManager = FindObjectOfType<FriendsCountManager>();
        UpdateBuildingAppearance();
    }
    public void UpdateBuildingAppearance()
    {
        int buildingIndex = 0;

        if (friendsCountManager.friendsCount >= 10)
            buildingIndex = 2;  // 아파트
        else if (friendsCountManager.friendsCount >= 5)
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
