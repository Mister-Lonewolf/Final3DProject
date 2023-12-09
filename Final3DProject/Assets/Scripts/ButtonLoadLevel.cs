using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ButtonLoadLevel : MonoBehaviour
    {
        public string LevelToLoad;
        
        public void LoadLevel()
        {
            GameManagerScript.ResetGame();
            GetScore.ResetScore();
            TrashControl.ResetTrashSpawning();
            Inventory.RemoveInventory();
            SwitchCamera.ResetCameras();
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}