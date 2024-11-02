using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStateMachine : StateMachine{
    [SerializeField] private int anger;
    [SerializeField] private int maxAnger = 100;
    [SerializeField] private float speed = 6f; public float Speed {get => speed;}
    [SerializeField] private float dashSpeed = 20f; public float DashSpeed {get => dashSpeed;}
    [SerializeField] private float chaseSpeed = 3f; public float ChaseSpeed {get => chaseSpeed;}
    [SerializeField] private float attackDelay = 0.5f; public float AttackDelay {get => attackDelay;}
    [SerializeField] private float attackCadence = 0.2f; public float AttackCadence {get => attackCadence;}
    [SerializeField] private float aimSpeed = 0.5f; public float AimSpeed {get => aimSpeed;}
    [SerializeField] private Transform attackTarget; public Transform AttackTarget {get => attackTarget;}
    [SerializeField] private Transform attackSpawner;
    [SerializeField] private List<GameObject> projectiles = new List<GameObject>();
    [SerializeField] private Animator anim; public Animator Anim {get => anim;}

    void Awake(){
        StateList.Add("PATROL", GetComponent<CatPatrol>());
        StateList.Add("AIM", GetComponent<CatAim>());
        StateList.Add("DASH", GetComponent<CatDash>());
        StateList.Add("CHASE", GetComponent<CatChase>());
        StateList.Add("CALM", GetComponent<CatCalm>());
        ChangeState(initialState);
        anger = maxAnger;
    }

    public void CheckAnger(){
        if(anger > 80)
            ChangeState("PATROL");
        else if(anger <= 80 && anger > 60)
            ChangeState("AIM");
        else if(anger <= 60 && anger > 30)
            ChangeState("DASH");
        else if(anger <= 30 && anger > 0)
            ChangeState("CHASE");
        else
            ChangeState("CALM");
    }

    public void ChangeAnger(int value){
        anger += value;
        if(anger >= 0){
            CheckAnger();
        }else{
            anger = 0;
        }
    }

    public void LaunchProjectile(int id){
        Instantiate(projectiles[id], attackSpawner.position, attackSpawner.rotation);
    }
}