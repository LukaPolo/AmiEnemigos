using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatState : State{
    protected CatStateMachine StateMachine;

    public virtual void Awake(){
        Initialize();
    }

    public override void Initialize(){
        StateMachine = GetComponent<CatStateMachine>();
    }
}