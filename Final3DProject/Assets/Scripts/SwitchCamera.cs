using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace Assets.Scripts
{
    public class SwitchCamera : MonoBehaviour
    {
        public GameObject Camera1;
        public GameObject Camera2;
        public GameObject Camera3;
        public GameObject Camera4;
        static bool reset = false;

        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Camera1") || reset)
            {
                reset = false;
                Camera1.SetActive(true);
                Camera2.SetActive(false);
                Camera3.SetActive(false);
                Camera4.SetActive(false);
            }
            if (CrossPlatformInputManager.GetButtonDown("Camera2"))
            {
                Camera1.SetActive(false);
                Camera2.SetActive(true);
                Camera3.SetActive(false);
                Camera4.SetActive(false);
            }
            if (CrossPlatformInputManager.GetButtonDown("Camera3"))
            {
                Camera1.SetActive(false);
                Camera2.SetActive(false);
                Camera3.SetActive(true);
                Camera4.SetActive(false);
            }
            if (CrossPlatformInputManager.GetButtonDown("Camera4"))
            {
                Camera1.SetActive(false);
                Camera2.SetActive(false);
                Camera3.SetActive(false);
                Camera4.SetActive(true);
            }
        }

        public static void ResetCameras()
        {
            reset = true;
        }
    }
}