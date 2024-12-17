using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource AmbienceSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip Music;
    public AudioClip Ambience1;
    public AudioClip Ambience2;
    public AudioClip Ambience3;
    public AudioClip walk1;
    public AudioClip walk2;
    List<AudioClip> lists = new List<AudioClip>();

    List<AudioClip> walks = new List<AudioClip>();
    private void Awake()
    {
        // Implement Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(MusicSource);
            DontDestroyOnLoad(AmbienceSource);
            DontDestroyOnLoad(SFXSource);

            lists.Add(Ambience1);
            lists.Add(Ambience2);
            lists.Add(Ambience3);

            MusicSource.clip = Music;
            MusicSource.Play();

            SFXSource.enabled = false;

            StartAmbience();

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void StartAmbience()
    {
        foreach (AudioClip clip in lists)
        {
            AmbienceSource.clip = clip;
            AmbienceSource.Play();
        }
    }

    public void WalkSFX()
    {
        SFXSource.enabled = true;

    }

    public void Deactivate()
    {
        SFXSource.enabled = false;

    }

    public void Walk()
    {
        walks.Add(walk1);
        walks.Add(walk2);
        foreach (AudioClip clip in walks)
        {
            SFXSource.clip  = clip;
            SFXSource.Play();
        }
    
    }
}
