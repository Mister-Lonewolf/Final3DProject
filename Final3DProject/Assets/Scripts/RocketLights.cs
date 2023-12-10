using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class RocketLights : MonoBehaviour
{
    public Health health;
    private int currentHealth;
    private Coroutine blinkCoroutine;
    public Light pointLight1;
    public Light pointLight2;
    public Light pointLight3;
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth != health.healthPoints)
        {
            currentHealth = (int)health.healthPoints;
            switch(currentHealth)
            {
                case 0:
                    pointLight1.enabled = false;
                    pointLight2.enabled = false;
                    pointLight3.enabled = false;
                    StopBlinking();
                    break;
                case 1:
                    pointLight1.enabled = true;
                    pointLight2.enabled = false;
                    pointLight3.enabled = false;
                    blinkCoroutine = StartCoroutine(BlinkLight());
                    break;
                case 2:
                    pointLight1.enabled = true;
                    pointLight2.enabled = true;
                    pointLight3.enabled = false;
                    StopBlinking();
                    break;
                default:
                    pointLight1.enabled = true;
                    pointLight2.enabled = true;
                    pointLight3.enabled = true;
                    StopBlinking();
                    break;
            }

        }
    }
    void StopBlinking()
    {
        // Stop de coroutine als deze actief is
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
        }
    }

    IEnumerator BlinkLight()
    {
        while (true)
        {
            // Wacht 200 milliseconden
            yield return new WaitForSeconds(0.2f);

            pointLight1.enabled = !pointLight1.enabled;
        }
    }
}
