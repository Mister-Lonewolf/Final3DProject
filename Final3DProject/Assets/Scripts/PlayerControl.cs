using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets.Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        public GameObject player;
        public float speed = 1;

        float horizontal = 0;
        float vertical = 0;

        void Update()
        {
            horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            if (player != null)
            {
                transform.Translate(speed * Time.deltaTime * vertical * Vector3.forward);
                transform.Translate(speed * Time.deltaTime * horizontal * Vector3.left);
            }
        }
    }
}