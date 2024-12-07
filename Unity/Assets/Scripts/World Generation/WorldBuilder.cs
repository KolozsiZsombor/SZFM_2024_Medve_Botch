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
            PlacePrefab(SelectedRoom, FreeRightAttachment, true);
            RoomsThisLevel--;
        }


    }

    /// <summary>
    /// Instantiates a given prefab at the given  attachment point,
    /// updates the location of the free attachment points.
    /// </summary>>
    /// <param name="roomPrefab">The prefab to instantiate.</param> 
    /// <param name="AttacherPosition">The attacher to place the prefab on.</param> 
    /// <param name="AttachmentSide">The side where the given attachment point is. False for left and True for right.</param> 
    public void PlacePrefab(GameObject roomPrefab, Vector3 AttacherPosition, bool AttachmentSide)
    {
        Vector3 LeftAttachment = roomPrefab.transform.Find("LeftAttachment").transform.position;
        Vector3 RightAttachment = roomPrefab.transform.Find("RightAttachment").transform.position;

        Vector3 PlacePoint = Vector3.zero;

        // If the attachment point is on the left.
        if (AttachmentSide == false)
        {
            PlacePoint.y = AttacherPosition.y + (RightAttachment.y * -1);
            PlacePoint.x = AttacherPosition.x + (RightAttachment.x * -1);
            Instantiate(roomPrefab, PlacePoint, Quaternion.identity);
        }
        else
        {
            PlacePoint.y = AttacherPosition.y + (LeftAttachment.y * -1);
            PlacePoint.x = AttacherPosition.x + (LeftAttachment.x * -1);
            Instantiate(roomPrefab, PlacePoint, Quaternion.identity);
        }
        script = FindObjectOfType<RoomDescriptor>();
        FreeLeftAttachment = script.GetLeftPosition();
        FreeRightAttachment = script.GetRightPosition();
    }
}
