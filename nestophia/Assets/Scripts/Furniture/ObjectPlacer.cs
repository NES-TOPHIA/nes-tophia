using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPlacer : MonoBehaviour
{
    public List<GameObject> placedGameObjects = new();

    public int PlaceObject(GameObject prefab, Vector3 position)
    {
        GameObject newObject = Instantiate(prefab);
        // position.y = 1.3f; 
        // 여기를 조정
        newObject.transform.position = position;
        placedGameObjects.Add(newObject);

        return placedGameObjects.Count - 1;
    }

    internal void RemoveObjectAt(int gameObjectIndex)
    {
        if (placedGameObjects.Count <= gameObjectIndex || placedGameObjects[gameObjectIndex] == null)
            return;

        Destroy(placedGameObjects[gameObjectIndex]);
        placedGameObjects[gameObjectIndex] = null;
    }
}
