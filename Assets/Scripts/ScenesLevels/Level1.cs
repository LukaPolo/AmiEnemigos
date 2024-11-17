using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour{
    void Awake(){
        ObjectHelder.lastFoodHeld += VictoryEnd;
        Rat.ratDied += DefeatEnd;
    }

    void OnDisable(){
        ObjectHelder.lastFoodHeld -= VictoryEnd;
        Rat.ratDied -= DefeatEnd;
    }

    public void VictoryEnd(){
        StartCoroutine(LevelEndCounter("Victory", 2f));
    }

    public void DefeatEnd(){
        StartCoroutine(LevelEndCounter("GameOver", 2f));
    }

    public IEnumerator LevelEndCounter(string sceneName, float time){
        yield return new WaitForSeconds(time);
        GameManager.Instance.LoadScene(sceneName);
    }
}