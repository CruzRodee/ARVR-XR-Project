using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;
    [SerializeField] private List<AudioSource> audioSources = new List<AudioSource>();

    void Awake()
    {
        // Ensure there's only one instance of AudioManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Register an AudioSource with the manager
    public void RegisterAudioSource(AudioSource source)
    {
        if (!audioSources.Contains(source))
        {
            audioSources.Add(source);
        }
    }

    // Stop all other audio sources when one starts playing
    public void StopOtherAudioSources(AudioSource currentSource)
    {
        foreach (AudioSource source in audioSources)
        {
            if (source != currentSource && source.isPlaying)
            {
                source.Stop();
            }
        }
    }
}
