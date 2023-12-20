using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public AudioClip audioStartGame;
    public AudioClip audioGameOver;
    public GameObject Camera;
    public GameObject TimeScoreCanvas;
    public GameObject GameOverCanvas;
    public GameObject PauseCanvas;
    public GameObject MenuCanvas;
    public Button StartButton;
    public Button MainMenuButton;
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

                // click on button to start the game
                StartButton.onClick.AddListener(delegate
                {
                    // play GameStart sound at camera position
                    if (audioStartGame)
                    {
                        if (gameObject.GetComponent<AudioSource>())
                        {
                            gameObject.GetComponent<AudioSource>().PlayOneShot(audioStartGame);
                        }
                        else
                        {
                            AudioSource.PlayClipAtPoint(audioStartGame, Camera.transform.position);
                        }
                    }
                    MenuCanvas.SetActive(false); // disable menucanvas
                    TimeScoreCanvas.SetActive(true); // enable timescorecanvas
                    gameState = GameStates.Playing; // change state to playing
                    Time.timeScale = 1f; // set timescale back to continue
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

                // pause if escape is pressed
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
