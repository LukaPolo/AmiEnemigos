using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour{
    [SerializeField] private GameObject pauseMenu;

    void Awake(){
        InputManager.pauseInput += PauseGame;
    }

    void OnDisable(){
        InputManager.pauseInput -= PauseGame;
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
    }

    public void LoadScene(string levelName){
        GameManager.Instance.LoadScene(levelName);
    }
}