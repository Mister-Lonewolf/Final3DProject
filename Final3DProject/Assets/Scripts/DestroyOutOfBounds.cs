using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    public float bound = 55.0f;
    private GameObject MainCharacterObject;
    private Vector3 pos_ScriptObject;
    private Vector3 pos_MainCharacterObject;
    private Vector3 pos_difference;
    void Start()
    {
        pos_ScriptObject = transform.position;  // Positie van het object waarop het script is toegepast
        MainCharacterObject = GameObject.FindWithTag("main_character");
        pos_MainCharacterObject = MainCharacterObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos_ScriptObject = transform.position;  // Positie van het object waarop het script is toegepast
        pos_MainCharacterObject = MainCharacterObject.transform.position;
        pos_difference = pos_MainCharacterObject - pos_ScriptObject;
        if (pos_difference.x > bound || pos_difference.y > bound || pos_difference.x < -bound || pos_difference.y < -bound )
            Destroy(gameObject);
    }
}