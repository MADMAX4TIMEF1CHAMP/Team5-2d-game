using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class PlaylistManager : MonoBehaviour
{
    public List<AudioClip> playlist; 
    public bool shuffle = false;

    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.loop = false;

        if (playlist.Count > 0)
        {
            StartCoroutine(PlayPlaylist());
        }
    }

    IEnumerator PlayPlaylist()
    {
        while (true) 
        {
            if (shuffle && currentTrackIndex == 0)
            {
                ShufflePlaylist();
            }

            audioSource.clip = playlist[currentTrackIndex];
            audioSource.Play();
            Debug.Log("Playing: " + audioSource.clip.name);

            yield return new WaitForSeconds(audioSource.clip.length);

            currentTrackIndex++;

            if (currentTrackIndex >= playlist.Count)
            {
                currentTrackIndex = 0;
            }
        }
    }

    void ShufflePlaylist()
    {
        for (int i = 0; i < playlist.Count; i++)
        {
            AudioClip temp = playlist[i];
            int randomIndex = Random.Range(i, playlist.Count);
            playlist[i] = playlist[randomIndex];
            playlist[randomIndex] = temp;
        }
    }
}