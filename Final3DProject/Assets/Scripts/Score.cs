using UnityEngine;

namespace Assets.Scripts
{
    public class Score : MonoBehaviour
    {
        private int score = 0;
        public void AddScore(int scoreToAdd)
        {
            score += scoreToAdd;
        }

        public void SubstractScore(int scoreToSubstract)
        {
            score -= scoreToSubstract;
        }

        public int GetScore()
        {
            return score;
        }
    }
}