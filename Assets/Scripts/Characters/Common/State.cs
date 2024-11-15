using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour{
    protected StateMachine StateMachine;

    public virtual void Initialize(){
        StateMachine = GetComponent<StateMachine>();
    }
}