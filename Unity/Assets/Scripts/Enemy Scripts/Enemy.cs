using Cainos.LucidEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, iDamageable
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private bool canSpawn = false;

    [Header("If can spawn")]
    [SerializeField] private GameObject spawnsWhat;
    [SerializeField] private int spawnHowManyInAvg=3;
    [SerializeField] private float timeToSpawnInAvg=6;
    private float currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;

        if (canSpawn)
        {
            StartCoroutine(SpawnEnemies());
        }


    }
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Took damage: " + damageAmount);

        if (currentHealth <= 0.1)
        {
            Debug.Log("Died");
            Destroy(gameObject);

            // Play sound effect
            //Drop loot
            // Go to next section in case of boss
        }

    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 spawnPos = Vector3.zero;
            float timeToSpawn = Random.Range(timeToSpawnInAvg - 2, timeToSpawnInAvg + 2);
            yield return new WaitForSeconds(timeToSpawn);
            int spawnNumber = Random.Range(spawnHowManyInAvg - 1, spawnHowManyInAvg + 1);
            
            for (int i = 0; i < spawnNumber; i++)
            {
                spawnPos.x= gameObject.transform.position.x - Random.Range(-1,1);
                spawnPos.y= gameObject.transform.position.y - Random.Range(-1,1);
                Instantiate(spawnsWhat, spawnPos, Quaternion.identity);
            }
        }
        

        
    }
}
