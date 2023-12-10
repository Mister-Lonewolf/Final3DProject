using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithBoolean : MonoBehaviour
{
    public Boolean enableDestroy = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enableDestroy)
            Destroy(gameObject); // Vernietig het object waarop dit script is toegepast
    }
}
