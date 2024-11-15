using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{
    [SerializeField] private SoundData musicList;
    private GameObject listener;
    private AudioSource musicSource;

    public void FindCamera(){
        if(listener == null){
            listener = GameObject.FindWithTag("MainCamera");
            musicSource = listener.AddComponent<AudioSource>();
        }
    }

    public void PlaySound(AudioClip sound){
        FindCamera();
        AudioSource source = listener.AddComponent<AudioSource>();
        source.clip = sound;
        source.Play();
        Destroy(source, sound.length);
    }

    public void PlayMusic(string musicName, bool loop){
        FindCamera();
        musicSource.clip = musicList.GetSound(musicName);
        musicSource.loop = loop;
        musicSource.Play();
    }
}