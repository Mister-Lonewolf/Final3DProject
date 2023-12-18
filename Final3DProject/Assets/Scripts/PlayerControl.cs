using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets.Scripts
{
    public class PlayerControl : MonoBehaviour
    {
        public GameObject player;
        public GameObject trashController;
        public float walkingSpeed = 1;
        public float rotateSpeed = 100;
        public AudioClip audioClip;
        
        private Animator animator;
        private Inventory inventory;
        private Score score;
        private float horizontal = 0;
        private float vertical = 0;

        private void Start()
        {
            animator = GetComponent<Animator>();
            inventory = GetComponent<Inventory>();
            score = GetComponent<Score>();
        }

        private void Update()
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

        private void OnCollisionStay(Collision collision)
        {
            if ((collision.gameObject.CompareTag("PMD") ||
                collision.gameObject.CompareTag("GFT") ||
                collision.gameObject.CompareTag("Paper") ||
                collision.gameObject.CompareTag("Rest")) &&
                CrossPlatformInputManager.GetButton("PickUp") &&
                inventory.IsEmpty())
            {
                inventory.SetInventory(collision.gameObject.tag);
                trashController.GetComponent<TrashControl>().RemoveTrash(collision.gameObject);
                AudioSource.PlayClipAtPoint(audioClip, transform.position, 50.0F);
            }
            if ((collision.gameObject.CompareTag("PMDBin") ||
                collision.gameObject.CompareTag("GFTBin") ||
                collision.gameObject.CompareTag("PaperBin") ||
                collision.gameObject.CompareTag("RestBin")) &&
                CrossPlatformInputManager.GetButton("PickUp") &&
                !inventory.IsEmpty())
            {
                if (collision.gameObject.tag.Contains(inventory.GetInventory()))
                {
                    score.AddScore(10);
                    trashController.GetComponent<TrashControl>().SpawnFaster();
                }
                else
                {
                    score.SubstractScore(5);
                }
                inventory.RemoveInventory();
                AudioSource.PlayClipAtPoint(audioClip, transform.position, 50.0F);
            }
        }
    }
}