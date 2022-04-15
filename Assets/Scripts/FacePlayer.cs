using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform target;
    public float turnRate;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
        Vector3 dir = target.position - transform.position;
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, turnRate * Time.deltaTime);
        }
        else target = GameObject.Find("SpaceShip").transform;
    }
}
