using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRegen : MonoBehaviour
{
    [SerializeField] public float regenAmount;
    [SerializeField] public float regenRate;
    private PlayerHealth health;

    void Start()
    {
        health = GameObject.Find("Player Sprite").GetComponent<PlayerHealth>();
        StartCoroutine(Regen());
    }

    IEnumerator Regen() {
        while(true){
            health.Heal(regenAmount);
            yield return new WaitForSeconds(regenRate);
        }
    }
    
}
