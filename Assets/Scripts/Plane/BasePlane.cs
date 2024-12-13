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

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responsiveModifier * 0.25f);
        rb.AddTorque(transform.right * pitch * responsiveModifier * 0.5f);
        rb.AddTorque(-transform.forward * roll * responsiveModifier * 0.1f);
    }
}
