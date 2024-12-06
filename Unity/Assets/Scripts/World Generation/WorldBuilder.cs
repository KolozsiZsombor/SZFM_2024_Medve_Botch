using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public GameObject StartingRoom;
    void Start()
    {
        Instantiate(StartingRoom, Vector3.zero, Quaternion.identity);
    }
}
