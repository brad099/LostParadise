using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CASP.SoundManager;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    public static SoundManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.Loop;
        }
    }

    private void Start() 
    {
        Play("Background", true);
        Play("Skate",true);
    }

    public void Play(string name, bool loopPlay) {
        Sound s = System.Array.Find(sounds, sound => sound.Name == name);
        if (s == null) {
            return;
        }

        if (!loopPlay) {
            // For completely play all sounds without cutting some last of sounds
            s.source.PlayOneShot(s.Clip);
        } else {
            s.source.Play();
        }
    }

    public void Stop(string name) {
        Sound s = System.Array.Find(sounds, sound => sound.Name == name);
        if (s == null) {
            return;
        }
        s.source.Stop();
    }

}
