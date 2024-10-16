using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStateMachine : StateMachine{
    [SerializeField] private int anger;

    void Awake(){
        StateList.Add("PATROL", GetComponent<CatPatrol>());
        StateList.Add("AIM", GetComponent<CatAim>());
        StateList.Add("DASH", GetComponent<CatDash>());
        StateList.Add("CHASE", GetComponent<CatChase>());
        StateList.Add("CALM", GetComponent<CatCalm>());
        ChangeState("PATROL");
    }

    void Start(){
        anger = 100;
    }
}