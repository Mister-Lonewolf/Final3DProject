using UnityEngine;

namespace Assets.Scripts
{
    public class TrashBin : MonoBehaviour
    {
        Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (animator != null && collision.gameObject.tag == "Player")
            {
                animator.SetBool("Open", true);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (animator != null && collision.gameObject.tag == "Player")
            {
                animator.SetBool("Open", false);
            }
        }
    }
}