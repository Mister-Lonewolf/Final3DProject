using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScorePoints : MonoBehaviour
{
    public float scorePoints = 0f;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score: " + scorePoints;
    }

    // Update is called once per frame

    public void ApplyScore(float amount)
    {
        scorePoints = scorePoints + amount;
        scoreText.text = "Score: " + scorePoints;

    }
}