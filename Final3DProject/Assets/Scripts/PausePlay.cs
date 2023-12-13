using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PausePlay : MonoBehaviour
    {
        public void Continue()
        {
            GameManagerScript.ContinueGame();
        }
    }
}