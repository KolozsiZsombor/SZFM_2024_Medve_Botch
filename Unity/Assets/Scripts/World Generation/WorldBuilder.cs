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
    public GameObject EndingRoom;
    public GameObject ShopRoom;
    public GameObject GiftRoom;
    public List<GameObject> RoomPrefabs;
    public int MinimumRoomsPerLevel = 4;
    public int MaximumRoomsPerLevel = 8;
    public RoomDescriptor script;
    private bool ShopRoomPlaced = false;
    private bool GiftRoomPlaced = false;
    public int CurrentLevel = 1;
    public int CurrentWorld = 1;
    private int RoomsPlaced = 0;
    private Vector3 FreeLeftAttachment;
    private Vector3 FreeRightAttachment;
    public int SideToPlaceOn;
    public int NumberOfRoomPrefabs;

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

        // The amount of rooms we can choose from.
        int numberOfRoomPrefabs = RoomPrefabs.Count;
        // Roll a random number for deciding how many rooms we are going to have this level.
        int RoomsThisLevel = UnityEngine.Random.Range(MinimumRoomsPerLevel, MaximumRoomsPerLevel);

        // The main loop for creating the level.
        while (RoomsThisLevel >= RoomsPlaced)
        {
            int SideToPlaceOn = UnityEngine.Random.Range(0, 2);
            GameObject SelectedRoom = RoomPrefabs[UnityEngine.Random.Range(0, numberOfRoomPrefabs)];

            // Deciding what to do based on the room selected, since some rooms require special treatment.
            // If we randomly selected the shop room.
            if (SelectedRoom == ShopRoom && !ShopRoomPlaced)
            {
                PlaceShopRoom();
            }
            // If we placed more than a third of all rooms this level and havent placed a shop yet.
            else if ((RoomsPlaced > RoomsThisLevel / 3) && !ShopRoomPlaced)
            {
                PlaceShopRoom();
            }
            // If we randomly selected the gift room.
            else if (SelectedRoom == GiftRoom && !GiftRoomPlaced)
            {
                PlaceGiftRoom();
            }
            // If we placed more than half of all rooms this level and havent placed a gift room yet.
            else if ((RoomsPlaced > RoomsThisLevel / 2) && !GiftRoomPlaced)
            {
                PlaceGiftRoom();
            }
            // If we selected a normal room.
            else
            {
                PlacePrefab(SelectedRoom, SideToPlaceOn);
                RoomsPlaced++;
            }
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

    /// <summary>
    /// Special function for placing the shop room.
    /// It places the shop then removes it from the list of spawnable rooms.
    /// Updates the RoomsPlaced and NumberOfRoomPrefabs variables.
    /// </summary>
    public void PlaceShopRoom()
    {
        PlacePrefab(ShopRoom, SideToPlaceOn);
        RoomPrefabs.Remove(ShopRoom);
        ShopRoomPlaced = true;
        RoomsPlaced++;
        NumberOfRoomPrefabs--;
    }

    /// <summary>
    /// Special function for placing the gift room.
    /// It places the gift room then removes it from the list of spawnable rooms.
    /// Updates the RoomsPlaced and NumberOfRoomPrefabs variables.
    /// </summary>
    public void PlaceGiftRoom()
    {
        PlacePrefab(GiftRoom, SideToPlaceOn);
        RoomPrefabs.Remove(GiftRoom);
        GiftRoomPlaced = true;
        RoomsPlaced++;
        NumberOfRoomPrefabs--;
    }
}
