using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;
    private int currentClip = 0;
    [SerializeField]
    private bool stopPlaying = false;
    public bool StopPlaying { 
        get
        {
            return stopPlaying;
        }
        private set
        {
            stopPlaying = value;

            audioSource.enabled = !stopPlaying;
        }
    }

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private AudioClip GetRandomClip()
    {
        currentClip = UnityEngine.Random.Range(0, clips.Length);
        return clips[currentClip];
    }

    private AudioClip GetClipByIndex(int i)
    {
        currentClip = i;
        return clips[i];
    }

    private AudioClip GetNextClip()
    {
        currentClip++;

        if(currentClip >= clips.Length)
        {
            currentClip = 0;
        }

        return clips[currentClip];
    }

    void Update()
    {
        if (!audioSource.isPlaying && clips.Length > 0 && StopPlaying == false)
        {
            audioSource.clip = GetNextClip();
            audioSource.Play();
        }
    }
}
