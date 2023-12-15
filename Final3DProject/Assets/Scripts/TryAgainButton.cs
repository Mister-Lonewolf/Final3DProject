using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour
{
    public void ReloadScene()
    {
        Debug.Log("reloading scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
