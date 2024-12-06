using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public GameObject StartingRoom;
    public List<GameObject> RoomPrefabs;

    void Start()
    {
        GameObject[] folderObjects = Resources.LoadAll<GameObject>("Prefabs/World1");

        Instantiate(StartingRoom, Vector3.zero, Quaternion.identity);

        foreach (GameObject i in folderObjects)
        {
            RoomPrefabs.Add(i);
        }

        int numberOfRoomPrefabs = RoomPrefabs.Count;

        if (numberOfRoomPrefabs == 0)
        {
            Debug.Log("No prefab rooms were found at the specified location.");
        }
        else
        {
            Debug.Log("The number of room prefabs: " +  numberOfRoomPrefabs);
        }
    }
}
