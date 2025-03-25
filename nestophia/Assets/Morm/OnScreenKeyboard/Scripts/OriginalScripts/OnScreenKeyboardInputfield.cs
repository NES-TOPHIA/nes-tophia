using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

//[RequireComponent(typeof(InputField))]
public class OnScreenKeyboardInputfield : MonoBehaviour, IPointerDownHandler
{
    public OnScreenKeyboard targetOnScreenKeyboard;
    private TMP_InputField _inputField;
    public string inputtedString;

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
        
        if (_inputField == null)
            return;

        _inputField.shouldHideMobileInput = true;
    }

    public void SaveInputedString(string _inputStr)
    {
        inputtedString = _inputStr;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (targetOnScreenKeyboard)
        {
            targetOnScreenKeyboard.gameObject.SetActive(true);
            targetOnScreenKeyboard.ShowKeyboard(_inputField, this);
        }
    }
}
