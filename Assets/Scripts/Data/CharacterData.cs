using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Character Data", menuName = "Character Data")]
public abstract class CharacterData : ScriptableObject{
    [SerializeField] protected SoundData soundList; public SoundData SoundList{get => soundList;}
    [SerializeField] protected float speed; public float Speed{get => speed;}
}