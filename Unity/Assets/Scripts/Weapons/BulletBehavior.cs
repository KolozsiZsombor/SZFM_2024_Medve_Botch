using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    Normal,
    Gravitational
}

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Properties properties;

    [Header("General Bullet Stats")]
    [SerializeField] private float range = 3f;
    [SerializeField] private LayerMask whatDestroysBullets;
    [SerializeField] private float bulletDamage;

    [Header("Normal Bullet Stats")]
    [Header("Gravitational Bullet Stats")]
    [SerializeField] private float gravVelocity = 5f;
    [SerializeField] private float gravity = 1f;
    public BulletType bulletType;
    [SerializeField] private float velocity;



    private void Start()
    {
        // Find and assign the Properties script from the weapon
        properties = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Properties>();

        // Copy all necessary properties from the weapon's Properties component
        CopyPropertiesToBullet();

        rb = GetComponent<Rigidbody2D>();

        // Initialize the velocity from the player’s weapon Properties component
        velocity = properties.projectileSpeed;


        // Initialize the bullet stats
        InitializeBulletStats();

        // Set the bullet's destroy time
        SetDestroyTime();

    }

    // Copy all stats from Properties to Bullet
    private void CopyPropertiesToBullet()
    {
        bulletDamage = properties.baseDamage;
        velocity = properties.projectileSpeed;
        range = properties.range;

    }

    private void InitializeBulletStats()
    {
        if (bulletType == BulletType.Normal)
        {
            SetStraightVelocity();
        }
        else if (bulletType == BulletType.Gravitational)
        {
            GravBullet();
        }
    }

    private void GravBullet()
    {
        rb.velocity = transform.right * gravVelocity;
        rb.gravityScale = gravity;
    }

    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * velocity; // Using the copied projectile speed
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, range);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is within the whatDestroysBullets layerMask
        if ((whatDestroysBullets.value & (1 << collision.gameObject.layer)) > 0)
        {
            // Spawn particles
            // Play sound FX
            // Damage enemy
            iDamageable idamageable = collision.gameObject.GetComponent<iDamageable>();
            if (idamageable != null)
            {
                // Damage enemy with the copied damage value
                idamageable.Damage(bulletDamage);
            }

            // Destroy the bullet game object
            Destroy(gameObject);
        }
    }
}
