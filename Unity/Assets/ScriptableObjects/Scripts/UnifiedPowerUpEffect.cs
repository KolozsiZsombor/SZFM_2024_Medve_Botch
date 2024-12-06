using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/UnifiedPowerUp")]
public class UnifiedPowerUp : PowerUpEffect
{
    public float attackSpeedBuff = 0;
    public float spreadBuff = 0;
    public int energyCostBuff = 0; // Use negative values to reduce cost
    public int energyRecoveryAmountBuff = 0;
    public float energyRecoverySpeedBuff = 0;
    public float projectileSpeedBuff = 0;
    public float damageBuff = 0f;

    public override void Apply(GameObject target)
    {
        Properties properties = target.GetComponentInChildren<Properties>();
        if (properties != null)
        {
            if (attackSpeedBuff != 0) properties.attackSpeed += attackSpeedBuff;
            if (spreadBuff != 0) properties.spread += spreadBuff;
            if (energyCostBuff != 0) properties.energyCost += energyCostBuff;
            if (energyRecoveryAmountBuff != 0) properties.engRecoveryAmount += energyRecoveryAmountBuff;
            if (energyRecoverySpeedBuff != 0) properties.engRecoverySpeed += energyRecoverySpeedBuff;
            if (projectileSpeedBuff != 0) properties.projectileSpeed += projectileSpeedBuff;
            if (damageBuff != 0) properties.baseDamage += damageBuff;
        }
        else
        {
            Debug.LogWarning("Target does not have a Properties component.");
        }
    }
}
