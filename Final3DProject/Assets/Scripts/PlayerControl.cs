using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets.Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        public GameObject player;
        public float walkingSpeed = 1;
        public float rotateSpeed = 100;

        Animator animator;

        float horizontal = 0;
        float vertical = 0;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            horizontal = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            vertical = CrossPlatformInputManager.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            if (player != null)
            {
                if (horizontal != 0 || vertical != 0) {
                    animator.SetTrigger("Walk");
                }
                transform.Translate(walkingSpeed * Time.deltaTime * vertical * Vector3.forward);
                transform.Rotate(rotateSpeed * Time.deltaTime * horizontal * Vector3.up);
            }
        }
    }
}