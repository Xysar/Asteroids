using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.Find("SpaceShip").transform;
        }
        else
        {
            transform.position = target.position + offset;
            boundCamera();
        }
    }

    void boundCamera()
    {
        Vector3 newPosition = transform.position;
        if (target.position.x < -360)
        {
            newPosition.x = -360;
        }
        if(target.position.x > 360)
        {
            newPosition.x = 360;
        }
        if(target.position.y < -260)
        {
            newPosition.y = -260;
        }
        if(target.position.y > 260)
        {
            newPosition.y = 260;
        }
        transform.position = newPosition;
    }
}
