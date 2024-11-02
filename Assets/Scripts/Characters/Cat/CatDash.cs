using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDash : CatState{
    [SerializeField] private Vector3 lastTargetPos;
    [SerializeField] private float timeSearching;

    void OnEnable(){
        timeSearching = 3f;
        StartCoroutine(DashAttack());
    }

    void OnDisable(){
        StopAllCoroutines();
        StateMachine.Anim.Play("Cat.Idle");
    }

    IEnumerator DashAttack(){
        while(true){
            // Bucle que se ejecutar� mientras el tiempo restante sea mayor que 0
            while(timeSearching > 0){
                timeSearching -= Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            lastTargetPos = StateMachine.AttackTarget.position;
            Vector2 direction = (StateMachine.AttackTarget.position - transform.position).normalized;
            if (direction.x >= 0){
                // Movimiento hacia la derecha
                StateMachine.Anim.Play("Cat.JumpRight");
            }else{
                // Movimiento hacia la izquierda
                StateMachine.Anim.Play("Cat.JumpLeft");
            }
            while(transform.position != lastTargetPos){
                transform.position = Vector3.MoveTowards(transform.position, lastTargetPos, StateMachine.DashSpeed * Time.deltaTime);
                yield return null;
            }
            timeSearching = 3f;
            StateMachine.Anim.Play("Cat.Idle");
        }
    }
}