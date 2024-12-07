using UnityEngine;

public class BossAI2D : MonoBehaviour,iDamageable
{
    public GameObject player;
     // Reference to the player
    public float speed = 2.0f; // Movement speed
    public float attackRange = 1.5f; // Distance to attack
    public float attackCooldown = 2.0f; // Time between attacks
    public int damage = 5; // Damage dealt by the boss
    public float maxHealth = 100f; // Boss's maximum health

    private float currentHealth; // Boss's current health
    private bool isAttacking = false; // To prevent overlapping attacks
    private bool isTakingDamage = false; // Prevent overlapping damage animations

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth; // Initialize health
    }

    void Update()
    {
        if (isTakingDamage) return; // Prevent any action during damage animation

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Check if the player is in attack range
        if (distanceToPlayer > attackRange)
        {
            StopAttacking(); // Stop attack if the player moves out of range
            MoveTowardsPlayer();
        }
        else
        {
            // Attack only if player is in range and not already attacking
            if (!isAttacking)
            {
                StartCoroutine(AttackPlayer());
            }
        }
    }
    void StopAttacking()
    {
        isAttacking = false;
        animator.ResetTrigger("Attack"); // Reset the attack trigger to avoid looping
    }
    void MoveTowardsPlayer()
    {
        if (isAttacking) return; // Do not move while attacking

        animator.SetBool("IsMoving", true); // Enable moving animation

        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Move boss toward the player
        rb.velocity = direction * speed; // Use rb.velocity instead of MovePosition for continuous movement

        // Flip the boss to face the player
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Face right
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Face left
        }
    }

    void StopMoving()
    {
        animator.SetBool("IsMoving", false); // Stop moving animation
        rb.velocity = Vector2.zero; // Stop movement
    }

    System.Collections.IEnumerator AttackPlayer()
    {
        if (isAttacking) yield break; // Prevent multiple simultaneous attacks

        isAttacking = true;
        animator.SetTrigger("Attack"); // Trigger attack animation


        // Wait for the attack animation to finish
        yield return new WaitForSeconds(attackCooldown);

        player.GetComponent<PlayerHealth>().TakeDamage(damage);
        isAttacking = false; // Allow boss to move again
    }


    private System.Collections.IEnumerator DamageAnimation()
    {
        isTakingDamage = true;
        animator.SetTrigger("TakeDamage"); // Play damage animation

        // Wait for the damage animation to finish
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        isTakingDamage = false;

        // After damage animation, check if the player is out of range to resume movement
        if (Vector2.Distance(transform.position, player.transform.position) > attackRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            StopMoving();
        }
    }


    void Die()
    {
        animator.SetTrigger("Die"); // Trigger death animation (optional)
        Debug.Log("Boss is dead!");
    }

    public void Damage(float damageAmount)
    {
        if (isTakingDamage) return; // Prevent overlapping damage animations

        currentHealth -= damageAmount; // Reduce boss's health
        Debug.Log($"Boss Health: {currentHealth}/{maxHealth}");

        
        if (currentHealth > 0)
        {
            StartCoroutine(DamageAnimation());
        }
        else
        {
            Die();
        }
    }
}
