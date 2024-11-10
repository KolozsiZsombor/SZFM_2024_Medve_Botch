using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    [Header("General Bullet Stats")]
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private LayerMask whatDestroysBullets;
    [SerializeField] private float bulletDamage = 5f;
    [Header("Normal Bullet Stats")]

    [SerializeField] private float velocity = 10f;
    [Header("Gravitational Bullet Stats")]
    [SerializeField] private float gravVelocity=5f;
    [SerializeField] private float gravity = 1f;
    public enum BulletType
    {

        Normal,
        Gravitational
    }
    public BulletType bulletType;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestroyTime();

        InitializeBulletStats();
        
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

        rb.velocity = transform.right * velocity;
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //is the collision within the whatDestroyBullet layerMask
        if ((whatDestroysBullets.value & (1<<collision.gameObject.layer)) >0) 
        {
            //spawn particles
            //play sound FX
            //Damage enemy
            iDamageable idamageable = collision.gameObject.GetComponent<iDamageable>();
            if (idamageable != null) 
            
            {
                //damage enemy
                idamageable.Damage(bulletDamage);
            
            }
            //Destroy game object

            Destroy(gameObject);        
        
        }
    }

}
