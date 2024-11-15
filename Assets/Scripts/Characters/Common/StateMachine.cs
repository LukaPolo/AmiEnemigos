using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour{
    [SerializeField] protected string initialState;
    [SerializeField] protected State currentState;
    [SerializeField] protected Dictionary<string, State> StateList = new Dictionary<string, State>();
    [SerializeField] private List<string> keys = new List<string>();
    [SerializeField] private List<State> values = new List<State>();

    void Awake(){
        for(int i = 0; i < keys.Count; i++){
            StateList.Add(keys[i], values[i]);
        }
        ChangeState(initialState);
    }

    public void ChangeState(string stateName){
        if(currentState != null && currentState != StateList[stateName]){
            currentState.enabled = false;
        }
        currentState = StateList[stateName];
        currentState.enabled = true;
    }
}