using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    private float attackSpeed = 0.25f;
    private float spread = 0.25f;
    private GameObject bulletInst;
    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    private float defaultScale;
    private float timeSinceLastShot = 0f;


    private void Start()
    {
        attackSpeed = weapon.GetComponent<Properties>().attackSpeed;
        spread = weapon.GetComponent<Properties>().spread;
        defaultScale = weapon.transform.localScale.y;
    }
    private void Update()
    {
        HandleGunRotation();
        HandleGunShooting();
    }
    private void HandleGunRotation()
    {

        //rotate the gun towards the mouse position

        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (worldPosition - (Vector2)weapon.transform.position).normalized;
        weapon.transform.right = direction;


        //flip the gun when it reaches a 90 degree threshold
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 localScale = new Vector3(1f, 1f, 1f);
        if (angle > 90 || angle < -90)
        {

            localScale.y = -defaultScale;
        }
        else
        {
            localScale.y = defaultScale;
        }

        weapon.transform.localScale = localScale;
    }

    private void HandleGunShooting()
    {
        timeSinceLastShot = timeSinceLastShot + Time.deltaTime;
        if (Input.GetMouseButton(0) && timeSinceLastShot > attackSpeed)
        {
            bulletSpawn.localRotation = Quaternion.Euler(new Vector3(bulletSpawn.localRotation.x,bulletSpawn.localRotation.y,Random.Range(-spread,spread)));
            bulletInst = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            timeSinceLastShot = 0f;
        }

    }
}

