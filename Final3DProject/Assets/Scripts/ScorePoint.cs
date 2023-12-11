using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag)
        {
            if (audioClip)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    // gameobject has audiosource
                    gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
                }
                else
                {
                    // add audiosource to gameobject: dynamically create object with audiosource, it will remove itself
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }
        }
        Destroy(other.gameObject);
    }
}
