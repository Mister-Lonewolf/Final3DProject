using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeightRocket : MonoBehaviour
{
    public bool enableWeight = false;
    public float weight = 0.03f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableWeight)
        {
            Debug.Log("mass changed");
            rb.mass = weight;
            enabled = false;
        }
    }
}
