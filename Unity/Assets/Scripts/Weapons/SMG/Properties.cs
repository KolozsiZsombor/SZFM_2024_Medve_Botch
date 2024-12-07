using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Properties : MonoBehaviour
{
    private void Start()
    {
        sout();
    }
    // Values are defined inside Unity
    [SerializeField] public float baseDamage;
    [SerializeField] public GameObject bullet;
    [SerializeField] public float attackSpeed;
    [SerializeField] public float spread;
    [SerializeField] public int energyCost;
    [SerializeField] public int engRecoveryAmount;
    [SerializeField] public float engRecoverySpeed;
    [SerializeField] public float projectileSpeed;
    

    public int sout()
    {
        Debug.Log("baseDamage" + baseDamage + "\n attackspeed" + attackSpeed + "\n spread" + spread + "\n energyCost" + energyCost + "\n engRecoveryAmount" + engRecoveryAmount + "\n engRecoverySpeed" + engRecoverySpeed  + "\n projectileSpeed" + projectileSpeed);
        return 0;
    }
}
