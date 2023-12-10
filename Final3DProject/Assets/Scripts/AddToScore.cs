using UnityEngine;
using System.Collections;

public class AddToScore : MonoBehaviour
{

    public float scoreAmount = 1.0f;
    public bool scoreOnTrigger = false;
    public bool scoreOnCollision = true;
    public bool continuousScore = false;

    void OnTriggerEnter(Collider collision)                     // used for things like bullets, which are triggers.  
    {
        if (scoreOnTrigger)
        {
            if (collision.gameObject.GetComponent<ScorePoints>() != null)
            {   // if the hit object has the Health script on it, deal damage
                collision.gameObject.GetComponent<ScorePoints>().ApplyScore(scoreAmount);
                // disable this script so it won't repeat
                scoreOnTrigger = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)                      // this is used for things that explode on impact and are NOT triggers
    {
        if (scoreOnCollision)
        {
            if (collision.gameObject.GetComponent<ScorePoints>() != null)
            {   // if the hit object has the Health script on it, deal damage
                collision.gameObject.GetComponent<ScorePoints>().ApplyScore(scoreAmount);
                //disable this script so it won't repeat
                scoreOnCollision = false;
            }
        }
    }
}