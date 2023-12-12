using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public GameObject TimeScoreCanvas;
    public GameObject GameOverCanvas;
    public enum GameStates
    {
        Playing,
        GameOver
    }

    public GameStates gameState = GameStates.Playing;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameStates.Playing:
                // game over if timer ends
                if (Mathf.FloorToInt(TimeScoreCanvas.GetComponent<TimeScoreManager>().timer) <= 0)
                {
                    gameState = GameStates.GameOver;
                    GameOverCanvas.SetActive(true);
                    GameObject.FindObjectOfType<MoveTrash>().GetComponent<MoveTrash>().enabled = false;
                }
                break;
        }
    }
}
