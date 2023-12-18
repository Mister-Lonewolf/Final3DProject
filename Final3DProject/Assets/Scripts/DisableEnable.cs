using System.Collections;
using UnityEngine;

public class DisableEnable : MonoBehaviour
{
    private bool verticalInput;
    private AudioSource audioSource;

    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        verticalInput = Input.GetKey(KeyCode.Space);
        if (verticalInput)
        {
            if (!gameObject.GetComponent<Renderer>().enabled)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                audioSource.Play();
            }
        }
        else
        {
            if (gameObject.GetComponent<Renderer>().enabled)
            {
                StartCoroutine(StopOnZeroCrossing());
            }
        }
    }

    IEnumerator StopOnZeroCrossing()
    {
        float[] samples = new float[audioSource.clip.samples];
        audioSource.clip.GetData(samples, 0);

        int crossingIndex = 0;

        // Vind het dichtstbijzijnde zero crossing
        for (int i = 0; i < samples.Length; i++)
        {
            if (samples[i] * samples[i + 1] < 0)
            {
                crossingIndex = i;
                break;
            }
        }

        // Wacht tot het eerstvolgende zero crossing
        yield return new WaitForSeconds((float)crossingIndex / audioSource.clip.frequency);

        // Stop de audio
        audioSource.Stop();

        // Zet het object onzichtbaar
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
