using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlane : MonoBehaviour
{
    public float throttleIncrement = 0.1f;
    public float maxThrust = 200f;
    public float mass = 400f;
    public float responsiveness = 10f;

    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;

    private float responsiveModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
    }

    private void HandleInputs()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        //keep throttle betweeen 0 and 100
        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    private void Update()
    {
        HandleInputs();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responsiveModifier * 0.25f);
        rb.AddTorque(transform.right * pitch * responsiveModifier * 0.5f);
        rb.AddTorque(-transform.forward * roll * responsiveModifier * 0.1f);
    }
}
