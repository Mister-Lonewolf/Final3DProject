using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSprite : MonoBehaviour
{

    public GameObject MainCharacterObject;
    public float waarde = 180.0f;
    public float triggerwaarde = 275.0f;
    private Vector3 pos_ScriptObject;
    private Vector3 pos_MainCharacterObject;
    private Vector3 pos_difference;
    public bool activateScript = false;

    // Start is called before the first frame update
    void Start()
    {
        pos_ScriptObject = transform.position;  // Positie van het object waarop het script is toegepast
        pos_MainCharacterObject = MainCharacterObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (activateScript)
        {
            pos_ScriptObject = transform.position;  // Positie van het object waarop het script is toegepast
            pos_MainCharacterObject = MainCharacterObject.transform.position;
            pos_difference = pos_MainCharacterObject - pos_ScriptObject;
            if (pos_difference.x > triggerwaarde)
                VeranderXPos(waarde, 1.0f);
            else if (pos_difference.x < -triggerwaarde)
                VeranderXPos(waarde, -1.0f);
            if (pos_difference.y > triggerwaarde)
                VeranderYPos(waarde, 1.0f);
            else if (pos_difference.y < -triggerwaarde)
                VeranderYPos(waarde, -1.0f);
        }


        void VeranderXPos(float waarde, float richting)
        {
            transform.position = new Vector3(transform.position.x + waarde * richting, transform.position.y, transform.position.z);
        }
        void VeranderYPos(float waarde, float richting)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + waarde * richting, transform.position.z);
        }
    }
}