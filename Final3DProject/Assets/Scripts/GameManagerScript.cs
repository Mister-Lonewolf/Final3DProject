using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManagerScript : MonoBehaviour
    {
        public GameObject pointsCanvas;
        public GameObject gameOverCanvas;
        public GameObject pauseGameCanvas;

        public static bool gameReset = false;
        public static bool pauseGame = false;

        void Update()
        {
            if (gameReset)
            {
                gameReset = false;
                pauseGame = false;
                pointsCanvas.SetActive(true);
                gameOverCanvas.SetActive(false);
                PlayerControl.EnableControl();
            }
            if (TrashControl.GameLost())
            {
                PlayerControl.DisableControl();
                SwitchCamera.ResetCameras();
                pointsCanvas.SetActive(false);
                gameOverCanvas.SetActive(true);
                pauseGameCanvas.SetActive(false);
            }
            if (pauseGame) {
                PlayerControl.DisableControl();
                SwitchCamera.ResetCameras();
                TrashControl.StopSpawning();
                pointsCanvas.SetActive(false);
                gameOverCanvas.SetActive(false);
                pauseGameCanvas.SetActive(true);
            }
            if (!pauseGame)
            {
                PlayerControl.EnableControl();
                TrashControl.StartSpawning();
                pointsCanvas.SetActive(true);
                gameOverCanvas.SetActive(false);
                pauseGameCanvas.SetActive(false);
            }
        }

        public static void ResetGame()
        {
            gameReset = true;
        }

        public static void PauseGame()
        {
            pauseGame = true;
        }

        public static void ContinueGame() {
            pauseGame = false;
        }
    }
}