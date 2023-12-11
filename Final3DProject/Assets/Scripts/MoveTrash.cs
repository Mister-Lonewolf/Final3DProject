using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrash : MonoBehaviour
{
    public AudioClip audioClip;
    private float spaceBetweenBins = 1f;
    private int binAmount = 4;
    private int poszFirstBin = 49;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // calculates the position of the farthest bin, depending on the number of bins and the distance betweens bins
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.z > poszFirstBin - binAmount*spaceBetweenBins + 1*spaceBetweenBins)
        {
            transform.Translate(0, 0, -spaceBetweenBins); // move ball one bin right
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.z < 49)
        {
            transform.Translate(0, 0, spaceBetweenBins); // move ball one bin left
        }
        // drop the ball in the bin
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
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
            Destroy(gameObject);
        }
    }
}
