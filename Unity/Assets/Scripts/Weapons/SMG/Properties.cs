using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    // Values are defined inside Unity
    [SerializeField] public float baseDamage;
    [SerializeField] public GameObject bullet;
    [SerializeField] public float attackSpeed;
    [SerializeField] public float spread;
    [SerializeField] public int energyCost;
    [SerializeField] public int engRecoveryAmount;
    [SerializeField] public float engRecoverySpeed;
    [SerializeField] public float projectileSpeed;
}
