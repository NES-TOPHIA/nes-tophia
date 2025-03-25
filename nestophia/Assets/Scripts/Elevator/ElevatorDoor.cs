using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ElevatorDoor : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    private bool canMove;
    private Vector3 doorLClosePosition;
    private Vector3 doorRClosePosition;

    [SerializeField] private float openSpeed;

    

    void Start()
    {
        canMove = false;
        doorLClosePosition = doorL.transform.position;
        doorRClosePosition = doorR.transform.position;
    }

    public void OnButtonPress()
    {
        if (!canMove)
        {
            canMove = true;
            Debug.Log("Controller button pressed, opening elevator doors!");
        }
    }

    // 새 Input System 이벤트 함수
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed && !canMove)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("SelectableBtn"))
                {
                    Debug.Log("btn click");
                    canMove = true;
                }
            }
        }
    }
    void Update()
    {
        if (canMove)
        {
            if (SceneManager.GetActiveScene().name == "HomeScene" || SceneManager.GetActiveScene().name == "Plaza")
            {
                GoElevator();
            }
            else if(SceneManager.GetActiveScene().name == "VRHomeScene" || SceneManager.GetActiveScene().name == "VRPlaza" )
            {
                GoVRElevator();
            }
            else if(SceneManager.GetActiveScene().name == "Elevator" || SceneManager.GetActiveScene().name == "VRElevator")
            {
                StartCoroutine(OpenAndCloseDoor());
            }
        }
    }

    IEnumerator OpenAndCloseDoor()
    {
        DoorOpen();

        while (doorL.transform.position.z < -2.1f && doorR.transform.position.z > 2.1f)
        {
            yield return null;
        }
        StartCoroutine(CloseDoorAfterDelay(6f));
    }

    public void GoElevator()
    {
        FindObjectOfType<SceneEffect>().FadeToScene("Elevator");
        Debug.Log("change Elevator Scene");
    }
    public void GoVRElevator()
    {
        FindObjectOfType<SceneEffect>().FadeToScene("VRElevator");
        Debug.Log("change Elevator Scene");
    }
    void DoorOpen()
    {
        if(doorL.transform.position.z >= -2.1f && doorR.transform.position.z <= 2.1f)
        {
            doorL.transform.Translate(Vector3.right * Time.deltaTime * openSpeed);
            doorR.transform.Translate(Vector3.left * Time.deltaTime * openSpeed);
        }
    }

    IEnumerator CloseDoorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DoorClose();
    }
    void DoorClose()
    {
        doorL.transform.position = Vector3.MoveTowards(doorL.transform.position, doorLClosePosition, openSpeed * Time.deltaTime);
        doorR.transform.position = Vector3.MoveTowards(doorR.transform.position, doorRClosePosition, openSpeed * Time.deltaTime);
        canMove = false;
    }
}

