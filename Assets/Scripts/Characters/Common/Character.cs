using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour{
    protected CharacterData characterData;
    protected StateMachine StateMachine;
    [SerializeField] protected Animator anim;
    [SerializeField] protected AudioSource source;
    private string currentAnim;

    public void Initialize(CharacterData data){
        characterData = data;
        StateMachine = GetComponent<StateMachine>();
        currentAnim = "";
    }

    public void PlayAnim(string animName){
        if(currentAnim != animName){
            currentAnim = animName;
            anim.Play(animName);
        }
    }

    public void PlaySound(string soundName, bool loop){
        source.clip = characterData.SoundList.GetSound(soundName);
        source.loop = loop;
        source.Play();
    }

    public void StopSound(){
        source.Stop();
    }

    public void PlayMusic(string musicName, bool loop){
        GameManager.Sound.PlayMusic(musicName, loop);
    }
}