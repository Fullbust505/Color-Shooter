using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class AudioSequencePlayer : MonoBehaviour
{
    public AudioSource firstAudioSource;  // Audio that plays on Awake
    public AudioSource secondAudioSource; // Audio that plays after, and loops

    private void Start()
    {
        if (firstAudioSource == null || secondAudioSource == null)
        {
            Debug.LogError("AudioSources are not assigned.");
            return;
        }

        // Ensure first audio does NOT loop
        firstAudioSource.loop = false;

        // Ensure second audio WILL loop
        secondAudioSource.loop = true;

        // Start first audio
        firstAudioSource.Play();

        // Start coroutine to wait until first finishes
        StartCoroutine(WaitAndPlaySecond());
    }

    private System.Collections.IEnumerator WaitAndPlaySecond()
    {
        yield return new WaitForSeconds(firstAudioSource.clip.length);

        secondAudioSource.Play();
    }
}
