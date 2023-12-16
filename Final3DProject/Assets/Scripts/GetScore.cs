using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GetScore : MonoBehaviour
    {
        public Text scoreText;
        public GameObject player;

        private void Start()
        {
            scoreText.text = "Score: 0";
        }

        private void Update()
        {
            scoreText.text = "Score: " + player.GetComponent<Score>().GetScore().ToString();
        }
    }
}