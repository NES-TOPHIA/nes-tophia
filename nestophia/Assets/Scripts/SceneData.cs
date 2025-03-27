using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneData : MonoBehaviour
{
    public static SceneData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 씬별 플레이어 설정값 (위치, 속도)
    private Dictionary<string, (Vector3 position, float speed)> sceneSettings = new Dictionary<string, (Vector3, float)>
    {
        { "Elevator", (new Vector3(4.05f, -1.3f, 0.85f),3.0f) },  
        { "HomeScene", (new Vector3(-2.0f, 0.3f, -3.0f), 3.0f) }, 
        { "Plaza", (new Vector3(-6.5f, -6.0f, -71.0f), 8.0f) }, 
        { "FurnitureScene", (new Vector3(15.0f, 0.0f, 15.0f), 0.0f) },
        { "VRElevator", (new Vector3(4f, -1f, 0.5f), 3.0f) },  
        { "VRHomeScene", (new Vector3(-1.0f, 0.2f, -2.0f), 4.0f) }, 
        { "VRPlaza", (new Vector3(-6.5f, -6.0f, -71.0f), 15.0f) }, 
        { "VRFurnitureScene", (new Vector3(15.0f, 0.0f, 15.0f), 0.0f) }
    };

    public (Vector3 position, float speed) GetSceneSettings(string sceneName)
    {
        if (sceneSettings.ContainsKey(sceneName))
            return sceneSettings[sceneName];
        return (Vector3.zero, 3.0f); // 기본값
    }
}
