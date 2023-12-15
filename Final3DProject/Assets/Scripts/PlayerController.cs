using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float forwardSpeed = 500.0f;
    [SerializeField] private float turnSpeed = 45.0f;
    [SerializeField] private float gravityMod = 1.3f;
    public bool enableSteering = false;
    private float horizontalInput;
    private float verticalInput;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * forwardSpeed * verticalInput);
        if (enableSteering)
            horizontalInput = Input.GetAxis("Horizontal");
            rb.AddRelativeTorque(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);

    }
}
