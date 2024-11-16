using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private int currentEnemies;
    [SerializeField] private int numberOfEnemySpawns=3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "Player")
        {
            currentEnemies = 0;
            StartCoroutine(SpawnRoutine());
            

        }
    }
    IEnumerator SpawnRoutine()
    {
        Vector3 spawnPos = Vector3.zero;
        while (currentEnemies < numberOfEnemySpawns)
        {

            yield return new WaitForSeconds(1f);

            spawnPos.x = Random.Range(-15,15);
            spawnPos.y = Random.Range(3, 5);
            Debug.Log("Spawning Enemy at :" + spawnPos);
            Instantiate(enemyPrefab,spawnPos, Quaternion.identity);
            currentEnemies++;
            
        }
    }
}
