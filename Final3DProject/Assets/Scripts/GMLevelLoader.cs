using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMLevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int sceneNumber;
    // load scene by index number
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
