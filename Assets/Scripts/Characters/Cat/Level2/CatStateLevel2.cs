using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatStateLevel2 : State{
    protected CatMovement Cat;

    void Awake(){
        Initialize();
    }

    public override void Initialize(){
        base.Initialize();
        Cat = GetComponent<CatMovement>();
    }
}