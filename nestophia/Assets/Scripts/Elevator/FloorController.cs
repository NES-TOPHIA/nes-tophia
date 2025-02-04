using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public GameObject[] floors;
    public GameObject[] numbers;

    void Start()
    {
        InitilizeFloors();
    }

    void InitilizeFloors()
    {
        for(int i = 0; i < floors.Length; i++)
        {
            floors[i].SetActive(false);
            Debug.Log(floors[i]);
        }
        if (floors.Length > 1) floors[1].SetActive(true);  // 배열 범위 체크
    }

    void ClickFloor(int newIndex)
    {
        if (newIndex >= 0 && newIndex < floors.Length)  // 인덱스 범위 체크
        {
            for(int i = 0; i < floors.Length; i++)
            {
                floors[i].SetActive(false);
            }
            floors[newIndex].SetActive(true);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
                // 태그를 확인하고 클릭 처리
                switch(hit.collider.gameObject.tag)
                {
                    case "No.1":
                        ClickFloor(1);
                        break;
                    case "No.2":
                        ClickFloor(2);
                        break;
                    case "No.3":
                        ClickFloor(3);
                        break;
                    case "No.4":
                        ClickFloor(4);
                        break;
                    case "No.5":
                        ClickFloor(5);
                        break;
                    case "No.6":
                        ClickFloor(6);
                        break;
                    case "No.7":
                        ClickFloor(7);
                        break;
                    case "No.8":
                        ClickFloor(8);
                        break;
                    case "No.9":
                        ClickFloor(9);
                        break;
                    case "BellBtn":
                        Debug.Log("Bell");
                        break;
                }
            }
        }   
    }
}
