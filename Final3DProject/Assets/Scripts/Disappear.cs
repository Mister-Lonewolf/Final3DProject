using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour
{
    public float resizeDuration = 2.0f; // The total duration for resizing
    public int numberOfSteps = 5; // Number of steps in the resizing process

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ResizeOverTimeCoroutine());
        }
    }

    private IEnumerator ResizeOverTimeCoroutine()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = Vector3.zero;

        for (int i = 1; i <= numberOfSteps; i++)
        {
            float progress = i / (float)numberOfSteps;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, progress);

            yield return new WaitForSeconds(resizeDuration / numberOfSteps);
        }

        Destroy(gameObject);
    }
}
