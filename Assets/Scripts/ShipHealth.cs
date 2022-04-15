using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{

    public int health = 3;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
