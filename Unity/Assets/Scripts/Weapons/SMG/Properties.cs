using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Properties : MonoBehaviour
{

    // Values are defined inside Unity
    [SerializeField] public float baseDamage;
    [SerializeField] public GameObject bullet;
    [SerializeField] public float attackSpeed;
    [SerializeField] public float spread;
    [SerializeField] public float energyCost;
    [SerializeField] public float engRecoveryAmount;
    [SerializeField] public float engRecoverySpeed;
    [SerializeField] public float projectileSpeed;
    [SerializeField] public float range;
    
}
