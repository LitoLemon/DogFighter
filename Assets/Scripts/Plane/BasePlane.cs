using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlane : MonoBehaviour
{
    public float throttleIncrement = 0.1f;
    public float maxThrust = 200f;
    public float mass = 400f;
    public float responsiveness = 10f;

    protected float throttle;
    protected float roll;
    protected float pitch;
    protected float yaw;

    private float responsiveModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    protected Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
    }

    protected virtual void FixedUpdate()
    {
        rb.AddForce(maxThrust * throttle * transform.forward);
        rb.AddTorque(0.25f * responsiveModifier * yaw * transform.up);
        rb.AddTorque(0.5f * pitch * responsiveModifier * transform.right);
        rb.AddTorque(0.1f * responsiveModifier * roll * -transform.forward);
    }
}
