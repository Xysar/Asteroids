using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] gunPoints;
    Vector3 BulletOrigin;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;
            for (int i  = 0; i< gunPoints.Length; i++) {
                Transform e = gunPoints[i];
                BulletOrigin = e.position;
                Instantiate(bulletPrefab, BulletOrigin, e.rotation);
            }
            
        }
    }
}
