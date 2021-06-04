using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    
    public Sound[] sounds;
    public static AudioManager Instance;
    public bool isMusicOn = true;
    public bool isSFXOn = true;

    void Awake() {

        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    void Start() {
        Sound s = Array.Find(sounds, sound => sound.name == "Music");
        if(s == null) {
            Debug.LogWarning("Music not found!");
            return;
        }
        s.source.loop = true;
        s.source.Play();
    }

    /// <summary>
    /// This function is responsible for playing the given sound
    /// </summary>
    /// <param name="name"></param>
    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        if(s.source.isPlaying) {
            return;
        }

        s.source.Play();
    }

    /// <summary>
    /// This function is responsible for stoping the given sound
    /// </summary>
    /// <param name="name"></param>
    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    /// <summary>
    /// This function is responsible for toggling the game music
    /// </summary>
    public bool ToggleMusic() {
        Sound s = Array.Find(sounds, sound => sound.name == "Music");
        if(isMusicOn) {
            s.source.mute = true;
            isMusicOn = false;
        } else {
            s.source.mute = false;
            isMusicOn = true;
        }
            return isMusicOn;
    }

    /// <summary>
    /// This function is responsible for toggling the game sfx
    /// </summary>
    public bool ToggleSFX() {
        if(isSFXOn) {
            foreach(Sound sound in sounds) {
                if(sound.name != "Music") {
                    sound.source.mute = true;
                }
                isSFXOn = false;
            }
        } else {
            foreach(Sound sound in sounds) {
                if(sound.name != "Music") {
                    sound.source.mute = false;
                }
            }
            isSFXOn = true;
        }
            return isSFXOn;
    }
}
