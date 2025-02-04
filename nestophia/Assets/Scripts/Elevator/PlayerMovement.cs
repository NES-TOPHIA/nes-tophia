using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveController : MonoBehaviour
{
    public float moveSpeed = 3.0f; // 이동 속도 설정
    private Vector2 moveInput; // 이동 입력 저장 변수

    void Update()
    {
        MovePlayer();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); // Vector2 값 읽기
    }

    private void MovePlayer()
    {
        // W/S는 앞뒤 (Z축), A/D는 좌우 (X축) 방향으로 변환
        Vector3 moveDirection = new Vector3(-moveInput.y, 0, moveInput.x); 
        // 캐릭터를 월드 좌표 기준으로 이동 
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
