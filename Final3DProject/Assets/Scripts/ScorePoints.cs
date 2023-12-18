using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ScorePoints : MonoBehaviour
{
    public float scorePoints = 0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GOpointsText;
    public string scoreTextFormat = "Score: {0}";
    public string GOscoreTextFormat = "{0} points";

    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame

    public void ApplyScore(float amount)
    {
        scorePoints += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = string.Format(scoreTextFormat, scorePoints);
        GOpointsText.text = string.Format(GOscoreTextFormat, scorePoints);
    }
}