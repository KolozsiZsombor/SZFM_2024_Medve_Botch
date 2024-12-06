using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    public PowerUpEffect powerUpEffect;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = collision.gameObject;

            powerUpEffect.Apply(player);

            Destroy(gameObject);
        }
    }
}
