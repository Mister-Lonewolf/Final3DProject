using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrash : MonoBehaviour
{
    private float spaceBetweenBins = 1f;
    private List<float> binPos = new List<float>();
    private List<GameObject> trashVar;
    private int difficulty;
    private int binAmount;
    private float poszLeftBin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LevelManager tsm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        // get variables from the LevelManager
        difficulty = tsm.difficulty;
        binAmount = tsm.binAmount;
        poszLeftBin = tsm.poszLeftBin;
        spaceBetweenBins = tsm.spaceBetweenBins;
        trashVar = tsm.trashVar;
        binPos = tsm.binPos;

        // calculates the position of the farthest bin, depending on the number of bins and the distance betweens bins
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.z > poszLeftBin - (binAmount-1)*spaceBetweenBins && GetComponent<Rigidbody>().useGravity == false)
        {
            transform.Translate(0, 0, -spaceBetweenBins); // move ball one bin right
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.z < poszLeftBin && GetComponent<Rigidbody>().useGravity == false)
        {
            transform.Translate(0, 0, spaceBetweenBins); // move ball one bin left
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
        // Play GainPoint if it collides with an object (net) of the same tag 
        if (other.gameObject.tag == tag)
        {
            LevelManager.instance.AddPoint(); // add point to the score text
        }
        // Play LosePoint if it collides with object (net) of another tag
        else if (other.gameObject.tag != tag)
        {
            LevelManager.instance.LosePoint(); // reduce point from the score text
        }
        
        // destroy the trash and make a new trash to continue playing
        Destroy(gameObject);
        int randomPos = Random.Range(0, binAmount); // generate random starting position for new trash
        int randomTrash = Random.Range(0, trashVar.Count); // generate random trash variant
        // make new Trash gameObject
        GameObject newTrash = Instantiate(trashVar[randomTrash], new Vector3(10.5f, 1.5f, binPos[randomPos]), transform.rotation);
        newTrash.GetComponent<Rigidbody>().useGravity = false; // disable gravity
        newTrash.GetComponent<MoveTrash>().enabled = true; // reactivate the script
    }
}
