using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    [SerializeField] public float attackSpeed = 0.15f;
    [SerializeField] public float spread = 15f;
    [SerializeField] public int energyCost = 1;
    [SerializeField] public int engRecoveryAmount = 10;
    [SerializeField] public float engRecoverySpeed = 2f;
}
