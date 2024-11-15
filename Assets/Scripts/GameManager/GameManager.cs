using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;
    public static SoundManager Sound;

    void Awake(){
        if(Instance == null){ //Se asegura que solo haya un objeto de este tipo
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Sound = GetComponent<SoundManager>();
        }else{
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Application.Quit()");
    }
}