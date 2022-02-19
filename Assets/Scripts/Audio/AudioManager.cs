using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public SFXSound[] sfxSounds;
    public MusicAttributes music;

    [Header("Mixer")]
    public AudioMixer master;
    public bool muted = false;
    private float musicVol, sfxVol, voicesVol;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);



        Init();


        master.GetFloat("musicVol", out musicVol);
        master.GetFloat("sfxVol", out sfxVol);
        master.GetFloat("voicesVol", out voicesVol);

    }
    public void Play(string name)
    {
        SFXSound s = Array.Find(sfxSounds, sound => sound.name == name);
        if (s != null)
            s.source.Play();
    }
    public void PlayMusic()
    {
        Sound s = Array.Find(music.musics, sound => sound.name == "music");
        if (s != null)
        {
            music.musicSources[0].clip = s.audioClip;
            music.musicSources[0].pitch = s.pitch;
            music.musicSources[0].volume = s.volume;
            music.musicSources[0].Play();
        }
    }
    public void PlaySubMusic(string name,bool loop=false)
    {
        Sound s = Array.Find(music.musics, sound => sound.name == name);
        if (s != null)
        {
            music.musicSources[1].loop = loop;
            music.musicSources[1].clip = s.audioClip;
            music.musicSources[1].pitch = s.pitch;
            music.musicSources[1].volume = s.volume;
            music.musicSources[1].Play();
            music.subMusicOn.TransitionTo(1);
            StartCoroutine(Waitformusic2());
        }

    }
    public void StopSubMusic()
    {
        if (music.musicSources[1].isPlaying)
        {
            music.musicSources[1].Stop();
        }
    }
    public void Setting(bool music, bool sFX, bool voice)
    {
        master.SetFloat("musicVol", Convertbooltoint(music, "musicVol", ref musicVol));
        master.SetFloat("sfxVol", Convertbooltoint(sFX, "sfxVol", ref sfxVol));
        master.SetFloat("voicesVol", Convertbooltoint(voice, "voicesVol", ref voicesVol));

    }

    void Init()
    {
        #region Music Initial
        music.musicSources[0] = gameObject.AddComponent<AudioSource>();
        music.musicSources[0].loop = true;
        music.musicSources[0].outputAudioMixerGroup = music.baseMusic;
        music.musicSources[1] = gameObject.AddComponent<AudioSource>();
        music.musicSources[1].outputAudioMixerGroup = music.subMusic;
        #endregion

        foreach (SFXSound s in sfxSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.audioClip;
            s.source.outputAudioMixerGroup = s.mixeroutput;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
        }
    }
    float Convertbooltoint(bool boolianObject, string toSetfloat, ref float a)
    {
        if (boolianObject) return a;
        else
        {
            master.GetFloat(toSetfloat, out a);
            return -80;
        }
    }
    public IEnumerator Waitformusic2()
    {
        yield return null;
        yield return new WaitUntil(() => music.musicSources[1].isPlaying == false);
        music.musicOn.TransitionTo(1);
    }
}
[System.Serializable]
public class MusicAttributes
{
    public Sound[] musics;
    [HideInInspector] public AudioSource[] musicSources = new AudioSource[2];
    public AudioMixerSnapshot musicOn, subMusicOn;
    public AudioMixerGroup baseMusic, subMusic;
}
