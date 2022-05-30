using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public HealthBar healthbar;
    public int maxHealth = 10;
    public int currentHealth;
    // Start is called before the first frame update
 

    private void Start()
    {
        GameObject UICanvas = GameObject.Find("UICanvas");
        Transform health = UICanvas.transform.Find("HealthBar");
        healthbar = (HealthBar)health.GetComponent(typeof(HealthBar));
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentHealth--;
        healthbar.setHealth(currentHealth);
    }
}
