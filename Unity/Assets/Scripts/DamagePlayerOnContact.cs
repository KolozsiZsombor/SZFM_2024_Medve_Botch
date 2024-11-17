using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnContact : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    private PlayerHealth playerHealth;
    [SerializeField] private bool isBullet=false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        if (playerHealth == null)
        {
            Debug.LogError("Player's PlayerHealth component not found. Make sure the player GameObject has a PlayerHealth script attached.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
        if (isBullet)
        {
            Destroy(gameObject);
        }
    }

}
