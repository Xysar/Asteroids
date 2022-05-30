using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OtherHealth : MonoBehaviour
{
    public int currentHealth = 3;

    void Update()
    {
        if (currentHealth <= 0)
        { 
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentHealth--;
    }
}
