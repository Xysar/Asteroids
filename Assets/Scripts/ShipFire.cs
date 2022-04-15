using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFire : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if(Input.GetButton("Fire1") && cooldownTimer<= 0)
        {
            cooldownTimer = fireDelay;
            Vector3 BulletOrigin = transform.Find("GunPoint").position;
            Instantiate(bulletPrefab, BulletOrigin, transform.rotation);
        }
    }
}
