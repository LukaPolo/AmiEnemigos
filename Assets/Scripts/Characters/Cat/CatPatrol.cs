using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPatrol : CatState{
    [SerializeField] private List<Transform> points = new List<Transform>(); //Lista que contiene las posiciones de los puntos del objeto)
    [SerializeField] private int targetPoint; //Objetivo de movimiento

    void OnEnable(){
        targetPoint = 0;
        InvokeRepeating("PatrolAttack", 0.5f, StateMachine.AttackDelay);
        StateMachine.Anim.Play("Cat.Attack");
    }
    void OnDisable(){
        CancelInvoke("PatrolAttack");
        StateMachine.Anim.Play("Cat.Idle");
    }

    void Update(){
        MoveBetweenPoints();
    }

    void MoveBetweenPoints(){
        if(targetPoint < points.Count){
            transform.position = Vector3.MoveTowards(transform.position, points[targetPoint].position, StateMachine.Speed * Time.deltaTime);
        }else{
            targetPoint = 0;
        }
        if(transform.position == points[targetPoint].position){
            targetPoint++;
        }
    }

    void PatrolAttack(){
        StateMachine.LaunchProjectile(0);
    }
}