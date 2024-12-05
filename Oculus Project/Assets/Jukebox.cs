using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Jukebox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip[] songs;
    private AudioSource audioSource;
    private int currentSongIndex = 0;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        if (songs.Length > 0)
        {
            audioSource.clip = songs[currentSongIndex];
        }
    }

    //public void PlayNextSong()
    //{
    //     if (songs.Length == 0) return;
    //     audioSource.clip = songs[currentSongIndex];
    //     audioSource.Play();

    //     currentSongIndex = (currentSongIndex + 1) % songs.Length;
    //}

    bool isPlaying = false; // Flag to check if audio is playing

    public void PlayNextSong()
    {
        if (songs.Length == 0) return;

        if (isPlaying)
        {
            // If currently playing, stop the audio
            audioSource.Stop();
            isPlaying = false;
        }
        else
        {
            // If not playing, play the next song
            audioSource.clip = songs[currentSongIndex];
            audioSource.Play();
            isPlaying = true;

            // Update the index for the next song
            currentSongIndex = (currentSongIndex + 1) % songs.Length;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
