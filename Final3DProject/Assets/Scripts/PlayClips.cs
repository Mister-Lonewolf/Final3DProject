using System;
using UnityEngine;

public class PlayClips : MonoBehaviour
{
    public AudioClip clipExpl1;
    public AudioClip clipExpl2;
    public AudioClip clipPickup;
    public bool expl1start = false;
    public bool expl2start = false;
    public bool pickupstart = false;

    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Check if AudioSource is not null
        if (audioSource != null)
        {
            // Set loop to false to play the audio clip only once
            audioSource.loop = false;
        }
        else
        {
            Debug.LogError("AudioSource is missing!");
        }
    }

    void Update()
    {
        if (expl1start && clipExpl1 != null)
        {
            PlayAudio(clipExpl1);
            expl1start = false;
        }

        if (expl2start && clipExpl2 != null)
        {
            PlayAudio(clipExpl2);
            expl2start = false;
        }

        if (pickupstart && clipPickup != null)
        {
            PlayAudio(clipPickup);
            pickupstart = false;
        }
    }

    void PlayAudio(AudioClip clip)
    {
        // Check if AudioSource and the provided audio clip are not null
        if (audioSource != null && clip != null)
        {
            // Assign the provided audio clip to the AudioSource
            audioSource.clip = clip;

            // Play the audio
            audioSource.Play();
        }
    }
}
