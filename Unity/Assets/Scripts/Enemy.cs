using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, iDamageable
{
    [SerializeField] private float maxHealth=10f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0.1 ) 
        { 
            Destroy(gameObject);
            // Play sound effect
            //Drop loot
            // Go to next section in case of boss
        }

    }
}
