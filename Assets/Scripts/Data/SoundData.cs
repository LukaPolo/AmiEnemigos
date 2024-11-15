using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Data", menuName = "Sound Data")]
public class SoundData : ScriptableObject{
    [SerializeField] private Dictionary<string, AudioClip> SoundList = new Dictionary<string, AudioClip>();
    [SerializeField] private List<string> keys = new List<string>();
    [SerializeField] private List<AudioClip> values = new List<AudioClip>();

    void OnEnable(){
        for(int i = 0; i < keys.Count; i++){
            SoundList.Add(keys[i], values[i]);
        }
    }

    public AudioClip GetSound(string soundName){
        return SoundList[soundName];
    }
}