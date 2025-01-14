﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    //singleton
    public static AudioManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.looping;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void Start()
    {
        Play("Ambient BG");
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == soundName);

        if(s == null)
        {
            Debug.LogWarning(soundName + " is not included in the manager, Please check if it is a typo.");
            return;
        }

        s.source.Play();
    }

}


