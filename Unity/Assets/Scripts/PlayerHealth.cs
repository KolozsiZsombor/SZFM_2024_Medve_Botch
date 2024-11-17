using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth<=0.1)
        {
            Die();
        }

    }

    private void Die()
    {
        //add death animation
        // go back to main menu
        //for now it resets scene
        Scene thisScene=SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);

    }
}
