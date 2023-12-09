using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManagerScript : MonoBehaviour
    {
        public GameObject pointsCanvas;
        public GameObject gameOverCanvas;

        public static bool gameReset = false;

        void Update()
        {
            if (gameReset)
            {
                gameReset = false;
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
            }
        }

        public static void ResetGame()
        {
            gameReset = true;
        }
    }
}