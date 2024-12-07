using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngineInternal;

public class WorldBuilder : MonoBehaviour
{
    public GameObject StartingRoom;
    public List<GameObject> RoomPrefabs;
    public int RoomsThisLevel = 4;
    public RoomDescriptor script;
    private Vector3 FreeLeftAttachment;
    private Vector3 FreeRightAttachment;

    void Start()
    {
        GameObject[] folderObjects = Resources.LoadAll<GameObject>("Prefabs/World1");

        // Add all of the GameObjects found in "Prefabs/World1 to a list."
        foreach (GameObject i in folderObjects)
        {
            RoomPrefabs.Add(i);
        }

        Instantiate(StartingRoom, Vector3.zero, Quaternion.identity);

        FreeLeftAttachment = StartingRoom.transform.Find("LeftAttachment").transform.position;
        FreeRightAttachment = StartingRoom.transform.Find("RightAttachment").transform.position;

        // We remove the Starting Room from the list of all prefabs to avoid spawning it.
        RoomPrefabs.Remove(StartingRoom);

        int numberOfRoomPrefabs = RoomPrefabs.Count;

        while (RoomsThisLevel > 0)
        {
            GameObject SelectedRoom = RoomPrefabs[UnityEngine.Random.Range(0, numberOfRoomPrefabs)];
            PlacePrefab(SelectedRoom, UnityEngine.Random.Range(0, 2));
            RoomsThisLevel--;
        }
    }

    /// <summary>
    /// Instantiates a given prefab at the given  attachment point,
    /// updates the location of the free attachment points.
    /// </summary>>
    /// <param name="roomPrefab">The prefab to instantiate.</param> 
    /// <param name="AttachmentSide">The side where the given attachment point is, 0 for left and 1 for right.</param> 
    public void PlacePrefab(GameObject roomPrefab, int AttachmentSide)
    {
        Vector3 RoomLeftAttachment = roomPrefab.transform.Find("LeftAttachment").transform.position;
        Vector3 RoomRightAttachment = roomPrefab.transform.Find("RightAttachment").transform.position;

        Vector3 PlacePoint = Vector3.zero;

        // If the attachment point is on the left.
        if (AttachmentSide == 0)
        {
            PlacePoint.y = FreeLeftAttachment.y + (RoomRightAttachment.y * -1);
            PlacePoint.x = FreeLeftAttachment.x + (RoomRightAttachment.x * -1);
            Instantiate(roomPrefab, PlacePoint, Quaternion.identity);
            script = FindObjectOfType<RoomDescriptor>();
            FreeLeftAttachment = script.GetLeftPosition();
        }
        // If the attachment point is on the right.
        if (AttachmentSide == 1)
        {
            PlacePoint.y = FreeRightAttachment.y + (RoomLeftAttachment.y * -1);
            PlacePoint.x = FreeRightAttachment.x + (RoomLeftAttachment.x * -1);
            Instantiate(roomPrefab, PlacePoint, Quaternion.identity);
            script = FindObjectOfType<RoomDescriptor>();
            FreeRightAttachment = script.GetRightPosition();

        }
    }
}
