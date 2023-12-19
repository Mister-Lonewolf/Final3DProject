using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Debug.Log("Loading MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}
