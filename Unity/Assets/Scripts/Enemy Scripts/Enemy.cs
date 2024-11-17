using Cainos.LucidEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Enemy : MonoBehaviour, iDamageable
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private bool canSpawn = false;
    [SerializeField] private bool canShoot = false;
    private GameObject player;

    [Header("If can spawn")]
    [SerializeField] private GameObject spawnsWhat;
    [SerializeField] private int spawnHowManyInAvg = 3;
    [SerializeField] private float timeToSpawnInAvg = 6;

    [Header("If can shoot")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;

    private float timer;


    private float currentHealth;
    private float force= 50000f;
    Rigidbody2D rb;



    private void Start()
    {
        currentHealth = maxHealth;
        rb=GetComponent<Rigidbody2D>();
        if (canSpawn)
        {
            StartCoroutine(SpawnEnemies());
        }
        if (canShoot) 
        {
            player = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(ShootAtPlayer());
        }



    }
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0.1)
        {
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
                spawnPos.x = gameObject.transform.position.x - Random.Range(-1, 1);
                spawnPos.y = gameObject.transform.position.y - Random.Range(-1, 1);
                Instantiate(spawnsWhat, spawnPos, Quaternion.identity);
            }
        }



    }
    private IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            if (Vector2.Distance(transform.position, player.transform.position) < 10)
            {
                Instantiate(bullet, bulletPos.position, Quaternion.identity);
            }
            else continue;
            


        }


    }

}
