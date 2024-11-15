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

    public void PlaySound(string soundName){
        source.PlayOneShot(characterData.SoundList.GetSound(soundName));
    }

    public void PlayMusic(string musicName, bool loop){
        GameManager.Sound.PlayMusic(musicName, loop);
    }
}