using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatState : State{
    protected Cat Cat;

    public virtual void Awake(){
        Initialize();
    }

    public override void Initialize(){
        Cat = GetComponent<Cat>();
    }
}