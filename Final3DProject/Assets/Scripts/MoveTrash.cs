using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrash : MonoBehaviour
{
    private float spaceBetweenBins = 1f;
    private List<float> binPos = new List<float>();
    private List<GameObject> trashVar;
    private int binAmount;
    private float poszLeftBin;
    private GameObject randomTrashObject;
    LevelManager tsm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tsm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        // get variables from the LevelManager
        binAmount = tsm.binAmount;
        poszLeftBin = tsm.poszLeftBin;
        spaceBetweenBins = tsm.spaceBetweenBins;

        // calculates the position of the farthest bin, depending on the number of bins and the distance betweens bins
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.z > poszLeftBin - (binAmount-1)*spaceBetweenBins && GetComponent<Rigidbody>().useGravity == false)
        {
            transform.position = transform.position + new Vector3(0, 0, -spaceBetweenBins); // move ball one bin right
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.z < poszLeftBin && GetComponent<Rigidbody>().useGravity == false)
        {
            transform.position = transform.position + new Vector3(0, 0, spaceBetweenBins); // move ball one bin left
        }
        
        // drop the ball in the bin
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    // When the trash collides with a net play a sound, edit score and create a new trash
    private void OnTriggerEnter(Collider other)
    {
        // play wiggle animation
        if (other.transform.parent.parent != null)
        {
            other.transform.parent.parent.GetComponent<Animator>().SetTrigger("wiggle");
        }

        // Play GainPoint if it collides with an object (net) of the same tag 
        if (other.gameObject.tag == tag)
        {
            other.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startColor = Color.yellow; // change particle color
            other.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play(); // play particle effect
            LevelManager.instance.AddPoint(); // add point to the score text
        }
        // Play LosePoint if it collides with object (net) of another tag
        else if (other.gameObject.tag != tag)
        {
            other.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startColor = Color.red; // change particle color
            other.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play(); // play particle effect
            LevelManager.instance.LosePoint(); // reduce point from the score text
        }        

        // destroy the trash and make a new trash to continue playing
        Destroy(gameObject);
        tsm.MakeTrash();
    }
}
