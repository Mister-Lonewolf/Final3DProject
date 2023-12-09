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
        public static bool disableControl = false;
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
            if (player != null && !disableControl)
            {
                if (horizontal != 0 || vertical != 0) {
                    animator.SetTrigger("Walk");
                }
                transform.Translate(walkingSpeed * Time.deltaTime * vertical * Vector3.forward);
                transform.Rotate(rotateSpeed * Time.deltaTime * horizontal * Vector3.up);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (!disableControl)
            {
                if ((collision.gameObject.CompareTag("PMD") ||
                    collision.gameObject.CompareTag("GFT") ||
                    collision.gameObject.CompareTag("Paper") ||
                    collision.gameObject.CompareTag("Rest")) &&
                    CrossPlatformInputManager.GetButton("PickUp") &&
                    Inventory.IsEmpty())
                {
                    Inventory.SetInventory(collision.gameObject.tag);
                    TrashControl.RemoveTrash(collision.gameObject);
                }
                if ((collision.gameObject.CompareTag("PMDBin") ||
                    collision.gameObject.CompareTag("GFTBin") ||
                    collision.gameObject.CompareTag("PaperBin") ||
                    collision.gameObject.CompareTag("RestBin")) &&
                    CrossPlatformInputManager.GetButton("PickUp") &&
                    !Inventory.IsEmpty())
                {
                    if (collision.gameObject.tag.Contains(Inventory.GetInventory()))
                    {
                        GetScore.AddScore(10);
                        TrashControl.SpawnFaster();
                    }
                    else
                    {
                        GetScore.SubstractScore(5);
                    }
                    Inventory.RemoveInventory();
                }
            }
        }

        public static void DisableControl()
        {
            disableControl = true;
        }

        public static void EnableControl()
        {
            disableControl = false;
        }
    }
}