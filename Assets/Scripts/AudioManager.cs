using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Sound [] sounds;
    public static AudioManager instance;
    [SerializeField] 
    private void Awake() {
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
        foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;
           s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }
        Play("game");
    }
    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       if(s == null)
       {
           Debug.Log("Звука " + name + " нету");
           return;
       }
       s.source.Play();
    }
    public AudioSource InformateAudioClip(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
       if(s == null)
       {
           Debug.Log("Звука " + name + " нету");
           return s.source;
       }
       return s.source;
    }
    public void Stop(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
       if(s == null)
       {
           Debug.Log("Звука " + name + " нету");
           return;
       }
       s.source.Stop();
    }
    public void StopAll()
    {
        for(int i = 0;i < sounds.Length;i++)
        {
            sounds[i].source.Stop();
        }
    }
}
