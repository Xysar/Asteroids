using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHealth : MonoBehaviour
{
    public int currentHealth = 1;
    void Update()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentHealth--;
    }
}
