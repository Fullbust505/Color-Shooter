using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SequentialAudioPlayer : MonoBehaviour
{
    public AudioClip introClip; // Played once
    public AudioClip loopClip;  // Looped forever after

    private AudioSource audioSource;
    private double startTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (introClip == null || loopClip == null)
        {
            Debug.LogError("Audio clips not assigned!");
            return;
        }

        // Play intro immediately
        audioSource.clip = introClip;
        audioSource.loop = false;
        audioSource.Play();

        // Schedule the looped clip
        double introDuration = (double)introClip.samples / introClip.frequency;
        startTime = AudioSettings.dspTime + introDuration;

        // Use a second AudioSource for clean scheduling
        AudioSource loopSource = gameObject.AddComponent<AudioSource>();
        loopSource.clip = loopClip;
        loopSource.loop = true;
        loopSource.PlayScheduled(startTime);
    }
}
