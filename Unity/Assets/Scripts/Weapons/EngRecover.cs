using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngRecover : MonoBehaviour
{
    public bool currentlyReloading = false;
    private float engRecoveryAmount;
    private float engRecoverySpeed;
    private EnergyBar energyBar;

    void Start(){
        engRecoveryAmount = GameObject.Find("Player Sprite").GetComponent<PlayerAimAndShoot>().weapon.GetComponent<Properties>().engRecoveryAmount;
        engRecoverySpeed = GameObject.Find("Player Sprite").GetComponent<PlayerAimAndShoot>().weapon.GetComponent<Properties>().engRecoverySpeed;
        energyBar = GameObject.Find("Energy bar").GetComponent<EnergyBar>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R) && !currentlyReloading){
            currentlyReloading = true;
            StartCoroutine(Recover());
        }
    }

    IEnumerator Recover(){
        yield return new WaitForSeconds(engRecoverySpeed);
        energyBar.RestoreEnergy(engRecoveryAmount);
        currentlyReloading = false;
    }
}
