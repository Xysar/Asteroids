using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float maxVelocity = 5f;
    public float velocityMult = 2;
    public float rotationSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxVelocity = 100f;
            velocityMult = 90f;
        }
        else
        {
            maxVelocity = 25f;
            velocityMult = 20f;
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
        Rotate(transform, -xAxis * rotationSpeed);
    }
}
