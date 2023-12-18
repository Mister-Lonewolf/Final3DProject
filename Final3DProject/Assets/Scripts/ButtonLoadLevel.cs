using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ButtonLoadLevel : MonoBehaviour
    {
        public string LevelToLoad;
        public GameObject GameManager;
        
        public void LoadLevel()
        {
            GameManager.GetComponent<GameManagerScript>().ResetGame();
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}