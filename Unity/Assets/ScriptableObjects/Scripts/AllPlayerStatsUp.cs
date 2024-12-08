using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/UnifiedPlayerBuff")]
public class UnifiedPlayerBuff : PowerUpEffect
{
    public float moveSpeedBuff = 0f;
    public float jumpForceBuff = 0f;
    public int maxHealthBuff = 0;
    public int currentHealthBuff = 0;
    public float regenAmountBuff = 0;
    public float regenRateBuff = 0;

    public override void Apply(GameObject target)
    {
        // PlayerController Buffs
        PlayerController controller = target.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.moveSpeed += moveSpeedBuff;
            controller.jumpForce += jumpForceBuff;
        }

        // PlayerHealth Buffs
        PlayerHealth health = target.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.maxHealth += maxHealthBuff;
            health.currentHealth = Mathf.Min(health.currentHealth + currentHealthBuff, health.maxHealth);
            health.UpdateHealthBar(health.currentHealth, health.maxHealth);
        }

        // PlayerRegen Buffs
        PlayerRegen regen = target.GetComponent<PlayerRegen>();
        if (regen != null)
        {
            regen.regenAmount += regenAmountBuff;
            regen.regenRate += regenRateBuff;
        }
    }
}
