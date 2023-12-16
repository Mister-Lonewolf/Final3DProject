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
    public float timer = 30f;
    int score = 0;
    public int difficulty = 0;

    public float poszLeftBin;
    private bool difficulty1Reached = false;
    private bool difficulty2Reached = false;
    private bool difficulty3Reached = false;
    private bool difficulty4Reached = false;
    private bool difficulty5Reached = false;

    public GameObject glasBin;
    public GameObject hplasticBin;

    public List<float> binPos = new List<float>(); // list with all the z positions of the bins
    public List<GameObject> trashVar; // list with all the trashvariants
    public int binAmount = 4;
    public float spaceBetweenBins = 1f;

    private GameObject[] allBinIconText;
    private GameObject[] allBinLids;
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        poszLeftBin = GameObject.Find("TrashbinPlastic").transform.position.z;

        scoreText.text = score.ToString();

        trashVar = new List<GameObject>(Resources.LoadAll<GameObject>("TrashPrefabs")); // load resource folder

        // add to list with all the bin positions
        for (int i = 0; i < binAmount; i++)
        {
            binPos.Add(poszLeftBin - spaceBetweenBins * i);
        }

        MakeTrash();
    }

    private void Update()
    {
        // countdown if timer is higher than zero
        if (Mathf.FloorToInt(timer) > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = $"Time left = {Mathf.FloorToInt(timer)}"; // write timer to canvas
        }

        // reach diff one if score 5
        if (score == 5 && !difficulty1Reached)
        {
            difficulty = 1; // increase difficulty
            binAmount = 5; // add a bin
            glasBin.SetActive(true); // make the new bin visible
            List<GameObject> trashVar1 = new List<GameObject>(Resources.LoadAll<GameObject>("Level1TrashPrefabs")); // load folder with level1 trash
            trashVar = trashVar.Union<GameObject>(trashVar1).ToList<GameObject>(); // unite previous list with the existing one
            binPos.Add(poszLeftBin - spaceBetweenBins * (binAmount - 1)); // add z position of new bin to list
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z - spaceBetweenBins / 2); // move camera
            difficulty1Reached = true;
        }

        // reach diff two if score 10
        if (score == 10 && !difficulty2Reached)
        {
            difficulty = 2; // increase difficulty
            binAmount = 6; // add a bin
            hplasticBin.SetActive(true); // make the new bin visible
            List<GameObject> trashVar1 = new List<GameObject>(Resources.LoadAll<GameObject>("Level2TrashPrefabs")); // load folder with level1 trash
            trashVar = trashVar.Union<GameObject>(trashVar1).ToList<GameObject>(); // unite previous list with the existing one
            binPos.Add(poszLeftBin - spaceBetweenBins * (binAmount - 1)); // add z position of new bin to list
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z - spaceBetweenBins / 2); // move camera
            difficulty2Reached = true;
        }

        // reach diff 3 if score 15
        if (score == 15 && !difficulty3Reached)
        {
            difficulty = 3;
            allBinIconText = GameObject.FindGameObjectsWithTag("IconText");
            for (int i = 0; i < binAmount; i++)
            {
                allBinIconText[i].SetActive(false);
            }
            difficulty3Reached = true;
        }

        // reach diff 4 if score 20
        if (score == 20 && !difficulty4Reached)
        {
            Camera.transform.Rotate(0, -180, 0, 0);
            Camera.transform.position = new Vector3(Camera.transform.position.x + 5.7f, Camera.transform.position.y, Camera.transform.position.z);
            allBinLids = GameObject.FindGameObjectsWithTag("Lid");
            for (int i = 0; i < binAmount; i++)
            {
                allBinLids[i].transform.Rotate(new Vector3(-95, 0, 0));
            }
            difficulty4Reached = true;
        }

        if (score == 25 && !difficulty5Reached)
        {
            for (int i = 0; i < binAmount; i++)
            {
                allBinLids[i].transform.Rotate(new Vector3(95, 0, 0));
            }
            difficulty5Reached = true;
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

    // make and generate a random trash from folder
    public void MakeTrash()
    {
        int randomPos = Random.Range(0, binAmount); // generate random starting position for new trash
        int randomTrash = Random.Range(0, trashVar.Count); // generate random trash variant

        // make new Trash gameObject
        GameObject newTrash = Instantiate(trashVar[randomTrash], new Vector3(10.5f, 1.5f, binPos[randomPos]), trashVar[randomTrash].transform.rotation);

        // make trigger if missing and enable it
        if (newTrash.GetComponent<SphereCollider>() == null)
        {
            newTrash.AddComponent<SphereCollider>();
            newTrash.GetComponent<SphereCollider>().isTrigger = true;
        }

        if (newTrash.GetComponent<Rigidbody>() == null)
        {
            newTrash.AddComponent<Rigidbody>(); // add rigidbody if missing
        }

        newTrash.GetComponent<Rigidbody>().useGravity = false; // disable gravity

        if (newTrash.GetComponent<MoveTrash>() == null)
        {
            newTrash.AddComponent<MoveTrash>(); // add script if script is missing
        }
        else
        {
            newTrash.GetComponent<MoveTrash>().enabled = true; // reactivate the script
        }
    }
}
