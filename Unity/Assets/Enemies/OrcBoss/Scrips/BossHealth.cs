using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class BossHealth : MonoBehaviour,iDamageable
{

    public float health = 500;
    Animator anim;
    [SerializeField] GameObject[] drops;
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
        if (drops  != null)
        {
            Vector2 vector= new Vector2(gameObject.transform.position.x, gameObject.transform.position.y+0.5f);
            Instantiate(drops[Random.Range(0, drops.Length)],vector,Quaternion.identity);
        }

        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        
    }

}