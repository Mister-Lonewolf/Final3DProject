using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    // Use this for initialization
    public AudioClip audioClip;
    public ParticleSystem explosionParticle;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision with enemy");
        if (other.gameObject.tag == "main_character")
        {
            Debug.Log("hit");
            Debug.Log(transform.position);
             Instantiate(explosionParticle, transform.position,transform.rotation);
            //DO explosion
            if (audioClip)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    //gameobject has audiosource
                    gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
                }
                else
                {

                    //add audiosource to gameobject: dynamically create object with audiosource,it will remove itself
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }

            Destroy(gameObject);
           
        }
    }
}
