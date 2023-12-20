using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenuButton : MonoBehaviour
    {
        public void LoadMainMenu()
        {
            Debug.Log("Loading MainMenu");
            SceneManager.LoadScene("MainMenu");
        }
    }
}