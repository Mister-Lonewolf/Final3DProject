using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public AudioClip audioGainPoint;
    public AudioClip audioLosePoint;
    public GameObject Camera;
    public Text scoreText;
    public Text timerText;
    public float timer = 60f;
    int score = 0;
    public int difficulty = 0;
    private bool level1Reached = false;

    public GameObject glasBin;

    public List<float> binPos = new List<float>(); // list with all the z positions of the bins
    public List<GameObject> trashVar; // list with all the trashvariants
    public int binAmount = 4;
    public float poszLeftBin;
    public float spaceBetweenBins = 1f;

    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();

        trashVar = new List<GameObject>(Resources.LoadAll<GameObject>("TrashPrefabs")); // load resource folder

        // add to list with all the bin positions
        for (int i = 0; i < binAmount; i++)
        {
            binPos.Add(poszLeftBin - spaceBetweenBins * i);
        }
    }

    private void Update()
    {
        // countdown if timer is higher than zero
        if (Mathf.FloorToInt(timer) > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = $"Time left = {Mathf.FloorToInt(timer)}"; // write timer to canvas
        }

        // reach level one if score 5
        if (score == 5 && !level1Reached)
        {
            difficulty = 1; // increase difficulty
            binAmount = 5; // add a bin
            glasBin.SetActive(true); // make the new bin visible
            List<GameObject> trashVar1 = new List<GameObject>(Resources.LoadAll<GameObject>("Level1TrashPrefabs")); // load folder with level1 trash
            trashVar = trashVar.Union<GameObject>(trashVar1).ToList<GameObject>(); // unite previous list with the existing one
            binPos.Add(poszLeftBin - spaceBetweenBins * (binAmount - 1)); // add z position of new bin to list
            print(binPos[4]);
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z - spaceBetweenBins / 2); // move camera
            level1Reached = true;
        }
    }
    // Update is called once per frame
    public void AddPoint()
    {
        // play audio if point is gained
        if (audioGainPoint)
        {
            if (gameObject.GetComponent<AudioSource>())
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(audioGainPoint);
            }
            else
            {
                AudioSource.PlayClipAtPoint(audioGainPoint, Camera.transform.position);
            }
        }
        score += 1; // add to score
        scoreText.text = score.ToString(); // write score to canvas
    }
    public void LosePoint()
    {
        // play audio if point is lost
        if (audioLosePoint)
        {
            if (gameObject.GetComponent<AudioSource>())
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(audioLosePoint);
            }
            else
            {
                AudioSource.PlayClipAtPoint(audioLosePoint, Camera.transform.position);
            }
        }
        // only lose points if score higher than 0
        if (score > 0)
        {
            score -= 1; // reduce point from score
            scoreText.text = score.ToString(); // write score to canvas
        }

    }
}
