using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour{
    [SerializeField] private string startMusic;
    [SerializeField] private bool loopStartMusic;

    void Start(){
        if(startMusic != ""){
            GameManager.Sound.PlayMusic(startMusic, loopStartMusic);
        }
    }

    public void LoadScene(string sceneName){
        GameManager.Instance.LoadScene(sceneName);
    }

    public void QuitGame(){
        GameManager.Instance.QuitGame();
    }
}