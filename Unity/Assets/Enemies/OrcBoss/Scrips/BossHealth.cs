using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class BossHealth : MonoBehaviour,iDamageable
{

    public float health = 500;
    Animator anim;

    public bool isInvulnerable = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Damage(float damage)
    {
        if (isInvulnerable)
            return;
        anim.SetTrigger("TakeDamage");
        
        health -= damage;

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (health <= 0)
        {
            anim.SetTrigger("Die");
            Die();
        }
    }

    void Die()
    {


        Destroy(gameObject);

        
    }

}