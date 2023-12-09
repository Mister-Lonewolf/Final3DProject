using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GetScore : MonoBehaviour
    {
        private static int score;
        public GameObject scoreText;


        void Start()
        {
            scoreText.GetComponent<Text>().text = "Score: 0";
        }

        void Update()
        {
            scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
        }

        public static void AddScore(int scoreToAdd)
        {
            score += scoreToAdd;
        }
        
        public static void SubstractScore(int scoreToSubstract)
        {
            score -= scoreToSubstract;
        }

        public static void ResetScore()
        {
            score = 0;
        }
    }
}