using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RatState : State{
    protected RatStateMachine StateMachine;

    public virtual void Awake(){
        Initialize();
    }

    public override void Initialize(){
        StateMachine = GetComponent<RatStateMachine>();
    }
}