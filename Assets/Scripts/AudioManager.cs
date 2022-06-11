using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        foreach(Sound sound in sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;

            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
    }

    public void PlaySound(string name)
    {
        var sound = GetAudioReference(name);
        if (sound == null)
        {
            return;
        }
        sound.Source.Play();
    }

    public void SetVolume(string name, float volume)
    {
        var sound = GetAudioReference(name);
        if (sound == null)
        {
            return;
        }
        sound.Source.volume = volume;
    }

    public Sound GetAudioReference(string name)
    {
        return Array.Find(sounds, sound => sound.Name == name);
    }
}
