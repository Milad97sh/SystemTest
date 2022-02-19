using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioClip;

    [Range(0,1)]
    public float volume=0.8f;
    [Range(0.1f,3)]
    public float pitch=1;

    public Sound()
    {
        volume = 1;
        pitch = 1;
    }
}

[System.Serializable]
public class SFXSound:Sound
{
    public AudioMixerGroup mixeroutput;
    [HideInInspector] public AudioSource source;
}
