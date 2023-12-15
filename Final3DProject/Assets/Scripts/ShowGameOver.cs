using UnityEngine;

public class ShowGameOver : MonoBehaviour
{
    private Renderer menuRenderer;

    void Start()
    {
        menuRenderer = GetComponent<Renderer>();

        // Initially hide the menu at startup
        HideMenu();
    }

    public void ShowMenu()
    {
        // Enable the renderer to make the menu visible
        menuRenderer.enabled = true;
    }

    public void HideMenu()
    {
        // Disable the renderer to make the menu invisible
        menuRenderer.enabled = false;
    }
}
