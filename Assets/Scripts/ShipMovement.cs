using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public HealthBar fuelBar;
    private Rigidbody2D rb;
    private ParticleSystem particle;
    public float maxVelocity = 5f;
    public float velocityMult = 2;
    public float rotationSpeed = 5;
    public int currentFuel = 100;
    public float fuelRate = 0.1f; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject Exhaust = GameObject.Find("ExhaustParticle");
        particle = Exhaust.GetComponent<ParticleSystem>();

        GameObject UICanvas = GameObject.Find("UICanvas");
        Transform health = UICanvas.transform.Find("FuelBar");
        fuelBar = (HealthBar)health.GetComponent(typeof(HealthBar));
        fuelBar.setMaxHealth(currentFuel);
    }

    // Update is called once per frame
    void Update()
    {
        fuelRate -= Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift) && currentFuel > 0)
        {
            maxVelocity = 100f;
            velocityMult = 90f;
            if (fuelRate < 0)
            {
                currentFuel--;
                fuelBar.setHealth(currentFuel);
                fuelRate = 0.02f;
            }
        }
        else
        {
            maxVelocity = 50f;
            velocityMult = 40f;
            if (fuelRate < 0)
            {
                currentFuel++;
                if (currentFuel > 100)
                {
                    currentFuel = 100;
                }
                fuelBar.setHealth(currentFuel);
                fuelRate = 0.03f;
            }
        }
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
         rb.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    private void FixedUpdate()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        ThrustForward(yAxis * velocityMult);
        if(yAxis > 0 && !particle.isPlaying)
        {
            particle.Play();
        }else if (yAxis < 1 && particle.isPlaying)
        {
            particle.Stop();
        }
        if (xAxis != 0)
        {
            Rotate(transform, -xAxis * rotationSpeed);
        }
       // else
            rb.angularVelocity *= .95f;
    }
}
