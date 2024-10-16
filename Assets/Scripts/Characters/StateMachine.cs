using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour{
    protected State currentState;
    protected Dictionary<string, State> StateList = new Dictionary<string, State>();

    public virtual void ChangeState(string stateName){
        if(currentState != null){
            currentState.enabled = false;
        }
        currentState = StateList[stateName];
        currentState.enabled = true;
    }
}