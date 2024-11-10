using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    private GameObject bulletInst;
    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    private float defaultScale;


    private void Start()
    {
        defaultScale=weapon.transform.localScale.y;
    }
    private void Update()
    {
        HandleGunRotation();
        HandleGunShooting();
    }
    private void HandleGunRotation()
    {

        //rotate the gun towards the ouse position

        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (worldPosition - (Vector2)weapon.transform.position).normalized;
        weapon.transform.right = direction;


        //flip the gun when it reaches a 90 degree threshold
        angle=Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 localScale = new Vector3(1f, 1f, 1f);
        if (angle >90 || angle < -90)
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
        if (Input.GetMouseButtonDown(0)){

            bulletInst = Instantiate(bullet, bulletSpawn.position,weapon.transform.rotation);
        }

    }
}
