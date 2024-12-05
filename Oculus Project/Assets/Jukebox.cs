using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Jukebox : MonoBehaviour
{

    [SerializeField] private AudioClip[] songs;

    private AudioSource audioSource;
    private int currentSongIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (songs.Length > 0)
        {
            audioSource.clip = songs[currentSongIndex];
        }

    }

    public void PlayNextSong()
    {
        if (songs.Length == 0) return;
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();

        currentSongIndex = (currentSongIndex + 1) % songs.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
