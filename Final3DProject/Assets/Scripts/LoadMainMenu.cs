using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ButtonMain : MonoBehaviour
    {
        public void LoadMenu()
        {
            Time.timeScale = 1f; // resume time
            Debug.Log("Loading MainMenu");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
