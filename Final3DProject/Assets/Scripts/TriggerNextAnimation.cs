using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextAnimation : MonoBehaviour
{
    public float speed = 1.0f;
    private Animator animator;
    private bool startFleeing = false;
    private float randomAngle;
    void Start()
    {
        animator = GetComponent<Animator>();
        randomAngle = Random.Range(-3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("TriggerAdvance");
                if (animator.runtimeAnimatorController.name == "SpiderFleeContr1"
                    || animator.runtimeAnimatorController.name =="SpiderFleeContr2")
                {
                    Debug.Log("spiderflee in actie");
                    startFleeing = true;
                }
            }
        }
        if (startFleeing)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * (12.0f*randomAngle) * Time.deltaTime); 
        }
    }
}
