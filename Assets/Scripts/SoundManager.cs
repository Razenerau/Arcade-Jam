using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    SHOOT_ANUBIS,
    SHOOT_HADES,
    BREAK_BLOCK
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource AudioSource;
    public AudioSource SoundtrackAudioSource;
    [SerializeField] private AudioClip[] _soundList;

    public AudioClip[] Soundtracks;
    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public static void PlaySound(SoundType sound, float volume = 1f)
    {
        Instance.AudioSource.PlayOneShot(Instance._soundList[(int)sound], volume);
    }

    public void PlayTitle()
    {
        SoundtrackAudioSource.Stop();
        SoundtrackAudioSource.clip = Soundtracks[0];
        SoundtrackAudioSource.Play();
    }

    public void PlayBattle()
    {
        SoundtrackAudioSource.Stop();
        SoundtrackAudioSource.clip = Soundtracks[1];
        SoundtrackAudioSource.Play();
    }

    public void PlayWin()
    {
        SoundtrackAudioSource.Stop();
        SoundtrackAudioSource.clip = Soundtracks[2];
        SoundtrackAudioSource.Play();
    }
}
