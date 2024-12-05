using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RoomDescriptor : MonoBehaviour
{
    public GameObject LeftAttachment;
    public GameObject RightAttachment;
    public GameObject EnemySpawns;

    private List<Transform> EnemySpawnsSet = new List<Transform>();

    void Start()
    {
        int i = 0;
        int NumOfEnemySpawns = EnemySpawns.transform.childCount;

        while (i < NumOfEnemySpawns)
        {
            Transform EnemySpawn = EnemySpawns.transform.GetChild(i);
            EnemySpawnsSet.Add(EnemySpawn);
            i++;
        }

        for (int j = 0; j < EnemySpawnsSet.Count(); j++)
        {
            Debug.Log(EnemySpawnsSet[j].transform.position);
        }
    }

    public List<Transform> GetEnemySpawns() { return EnemySpawnsSet; }

    public Transform GetLeftPosition() { return LeftAttachment.transform; }

    public Transform GetRightPosition() { return RightAttachment.transform; }
}
