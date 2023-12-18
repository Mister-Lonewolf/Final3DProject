using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets.Scripts
{
    public class GameManagerScript : MonoBehaviour
    {
        public GameObject pointsCanvas;
        public GameObject gameOverCanvas;
        public GameObject pauseGameCanvas;
        public GameObject player;
        public GameObject trashController;

        private bool gameReset = false;
        private bool pauseGame = false;

        private void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Cancel"))
            {
                pauseGame = true;
            }
            if (gameReset)
            {
                gameReset = false;
                pauseGame = false;
                trashController.GetComponent<TrashControl>().enabled = true;
                player.SetActive(true);
                pointsCanvas.SetActive(true);
                gameOverCanvas.SetActive(false);
            }
            if (trashController.GetComponent<TrashControl>().GameLost())
            {
                player.SetActive(false);
                trashController.GetComponent<TrashControl>().enabled = false;
                SwitchCamera.ResetCameras();
                pointsCanvas.SetActive(false);
                gameOverCanvas.SetActive(true);
                pauseGameCanvas.SetActive(false);
            }
            if (pauseGame) {
                SwitchCamera.ResetCameras();
                player.SetActive(false);
                trashController.GetComponent<TrashControl>().enabled = false;
                pointsCanvas.SetActive(false);
                gameOverCanvas.SetActive(false);
                pauseGameCanvas.SetActive(true);
            }
            if (!pauseGame && !trashController.GetComponent<TrashControl>().GameLost())
            {
                player.SetActive(true);
                trashController.GetComponent<TrashControl>().enabled = true;
                pointsCanvas.SetActive(true);
                gameOverCanvas.SetActive(false);
                pauseGameCanvas.SetActive(false);
            }
        }

        public void ResetGame()
        {
            gameReset = true;
        }

        public void ContinueGame()
        {
            pauseGame = false;
        }
    }
}