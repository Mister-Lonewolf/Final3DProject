using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScoreManager : MonoBehaviour
{
    public AudioClip audioGainPoint;
    public AudioClip audioLosePoint;
    public GameObject Camera;
    public static TimeScoreManager instance;
    public Text scoreText;
    public Text timerText;
    public float timer = 60f;
    int score = 0;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        if (Mathf.FloorToInt(timer) > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = $"Time left = {Mathf.FloorToInt(timer)}";
        }
    }
    // Update is called once per frame
    public void AddPoint()
    {
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
        score += 1;
        scoreText.text = score.ToString();
    }
    public void LosePoint()
    {
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
        if (score > 0)
        {
            score -= 1;
            scoreText.text = score.ToString();
        }

    }
}
