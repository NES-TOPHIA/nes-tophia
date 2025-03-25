using UnityEngine;
using TMPro;

public class DebugLogger : MonoBehaviour
{
    public TextMeshProUGUI logText; // UI에 연결할 TextMeshPro 객체
    private string logMessages = "";

    void Awake()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        logMessages += logString + "\n";
        logText.text = logMessages;
    }
}
