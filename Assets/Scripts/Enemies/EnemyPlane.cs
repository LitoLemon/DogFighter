using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : BasePlane
{
    public GameObject target;
    public float speed = 5f;
    public float stoppingDistance = 10f;
    // Update is called once per frame
    protected override void FixedUpdate()
    {
        Vector3 targetPos = target.transform.position;
        Vector3 currentPos = transform.position;

        float distance = Vector3.Distance(currentPos, targetPos);
        if (distance > stoppingDistance)
        {
            Vector3 travelDirection = targetPos - currentPos;
            travelDirection.Normalize();

            rb.MovePosition(currentPos + (travelDirection * speed * Time.fixedDeltaTime));

            transform.LookAt(targetPos);
        }
    }

}
