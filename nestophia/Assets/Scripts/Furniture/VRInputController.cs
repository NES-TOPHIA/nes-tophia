using System;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.InputSystem;

public class VRInputController : MonoBehaviour
{
    public Camera sceneCamera; // XR 카메라
    public LayerMask placementLayermask;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rightHandRay; // 컨트롤러에서 나가는 Ray
    public InputActionProperty selectAction; // XR 컨트롤러 트리거 버튼

    public event Action OnClicked, OnExit;

    private Vector3 lastPosition;

    void Update()
    {
        // 트리거 버튼 입력 확인
        if (selectAction.action.WasPressedThisFrame())
        {
            OnClicked?.Invoke();
        }

        // Exit (메뉴 버튼 or B/Y 버튼)
        if (Keyboard.current.escapeKey.wasPressedThisFrame) 
        {
            OnExit?.Invoke();
        }
    }

    public bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public Vector3 GetSelectedMapPosition()
    {
        RaycastHit hit;

        if (rightHandRay.TryGetCurrent3DRaycastHit(out hit) && ((1 << hit.collider.gameObject.layer) & placementLayermask) != 0)
        {
            lastPosition = hit.point;
        }

        return lastPosition;
    }
}