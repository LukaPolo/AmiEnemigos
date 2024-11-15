using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Character{
    public static Action angry, calmed, angerChanged;
    [SerializeField] private CatData data; public CatData Data{get => data;}
    [SerializeField] private int anger; public int Anger{get => anger;}
    [SerializeField] private Transform attackTarget; public Transform AttackTarget{get => attackTarget;}
    [SerializeField] private Transform attackSpawner;
    [SerializeField] private DamageHitbox attackHitbox; public DamageHitbox AttackHitbox{get => attackHitbox;}

    void Awake(){
        Initialize(Data);
        anger = Data.MaxAnger;
        attackTarget = GameObject.FindWithTag("Rat").transform;
        PlayMusic("CatAngry", true);
    }

    public void CheckAnger(){
        if(anger > 80)
            StateMachine.ChangeState("PATROL");
        else if(anger <= 80 && anger > 60)
            StateMachine.ChangeState("AIM");
        else if(anger <= 60 && anger > 30)
            StateMachine.ChangeState("DASH");
        else if(anger <= 30 && anger > 0)
            StateMachine.ChangeState("CHASE");
        else
            StateMachine.ChangeState("CALM");
    }

    public void ChangeAnger(int value){
        anger += value;
        if(anger > 0){
            angry?.Invoke();
        }else{
            anger = 0;
        }
        angerChanged?.Invoke();
        CheckAnger();
    }

    public void LaunchProjectile(int id){
        Instantiate(Data.Projectiles[id], attackSpawner.position, attackSpawner.rotation);
        PlaySound("Attack1");
    }
}