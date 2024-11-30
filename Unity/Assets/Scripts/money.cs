using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{

    [SerializeField] private int value;
    static int moneyAmount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){

            moneyAmount += value;
            Debug.Log(moneyAmount);
            Destroy(gameObject);
        }
            
    }

}

