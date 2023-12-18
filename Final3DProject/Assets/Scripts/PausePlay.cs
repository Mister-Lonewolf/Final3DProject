using UnityEngine;

namespace Assets.Scripts
{
    public class PausePlay : MonoBehaviour
    {
        public GameObject GameManager;
        public void Continue()
        {
            GameManager.GetComponent<GameManagerScript>().ContinueGame();
        }
    }
}