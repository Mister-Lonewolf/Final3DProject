using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public AudioClip audioGameOver;
    public GameObject Camera;
    public GameObject TimeScoreCanvas;
    public GameObject GameOverCanvas;
    public GameObject PauseCanvas;
    public GameObject MenuCanvas;
    public Button StartButton;
    public GameObject LevelManager;
    public enum GameStates
    {
        GameMenu,
        Playing,
        GameOver,
        Paused
    }

    public GameStates gameState = GameStates.GameMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameStates.GameMenu:
                Time.timeScale = 0f; // set timescale to 0 to pause level

                StartButton.onClick.AddListener(delegate
                {
                    MenuCanvas.SetActive(false);
                    TimeScoreCanvas.SetActive(true);
                    gameState = GameStates.Playing;
                    Time.timeScale = 1f; // set timescale to 0 to pause level
                });
                break;
            case GameStates.Playing:
                // game over if timer ends
                if (Mathf.FloorToInt(LevelManager.GetComponent<LevelManager>().timer) <= 0)
                {
                    gameState = GameStates.GameOver;
                    GameOverCanvas.SetActive(true);
                    Time.timeScale = 0f; // set timescale to 0 to pause level
                    
                    // play GameOver sound at camera position
                    if (audioGameOver)
                    {
                        if (gameObject.GetComponent<AudioSource>())
                        {
                            gameObject.GetComponent<AudioSource>().PlayOneShot(audioGameOver);
                        }
                        else
                        {
                            AudioSource.PlayClipAtPoint(audioGameOver, Camera.transform.position);
                        }
                    }
                }
                // pause if escape is prssed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    gameState = GameStates.Paused;
                    PauseCanvas.SetActive(true);
                    Time.timeScale = 0f;
                }
                break;
        }
    }
}
