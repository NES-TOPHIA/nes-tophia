using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FriendsCountManager : MonoBehaviour
{
    
    public TMP_Text friendsCountText;
    public GameObject friendsCountPanel;
    public int friendsCount = 0;
    [SerializeField]
    public BuildingEvolutionController buildingEvolutionController;  

    void Start()
    {
        UpdateUI();
    }

    void OnEnable()
    {
        // 씬 변경 감지 이벤트 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // 씬 변경 감지 이벤트 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

     void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // VRPlaza 씬으로 이동했을 때만 FriendsCountManager 찾기
        if (scene.name == "VRPlaza")
        {
            buildingEvolutionController = FindObjectOfType<BuildingEvolutionController>();

        }
        else
        {
            // 다른 씬으로 가면 연결 해제
            buildingEvolutionController = null;
        }
    }


    void UpdateUI()
    {
        friendsCountText.text = friendsCount.ToString();
        buildingEvolutionController.UpdateBuildingAppearance();
    }

    public void AddFriend()
    {
        friendsCount++;
        UpdateUI();
    }
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "VRPlaza")
        {
            friendsCountPanel.SetActive(true);
        }
        else
        {
            friendsCountPanel.SetActive(false);
        } 
    }
}
