using System.Collections;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic;
    private AudioSource audioSource;
    public bool enableMusic = false;
    public bool fadeOutMusic = false;
    private bool hasStarted = false;
    private bool hasStopped = false;
    public float fadeOutTime = 0.65f;  // Tijd in seconden voor het uitfaden

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = backgroundMusic;
        audioSource.volume = 0.3f;
    }

    void Update()
    {
        // check voor muziek te beginnen en ook te stoppen (uitfaden)

            if (enableMusic && !hasStarted)
            {
                PlayMusic();
                hasStarted = true;
            }
            else if (fadeOutMusic && hasStarted && !hasStopped)
            {
                StopMusic();
                hasStopped = true;
            }
        }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void StopMusic()
    {
        StartCoroutine(FadeOutAndStop());
    }

    System.Collections.IEnumerator FadeOutAndStop()
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeOutTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;  // Herstel het volume naar het oorspronkelijke niveau
    }
}
