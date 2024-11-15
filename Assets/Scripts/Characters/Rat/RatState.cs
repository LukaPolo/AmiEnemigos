using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RatState : State{
    protected Rat Rat;

    void Awake(){
        Initialize();
    }

    public override void Initialize(){
        base.Initialize();
        Rat = GetComponent<Rat>();
    }
}