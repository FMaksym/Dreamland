using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip _musicGame;

    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        _audioSource.Play();
    }
}
