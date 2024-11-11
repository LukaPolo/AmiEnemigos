using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatChase : CatState{
    void OnEnable(){
        StartCoroutine(ChaseTarget());
    }

    void OnDisable(){
        StopAllCoroutines();
        StateMachine.Anim.SetInteger("MoveDirection", 0);
        StateMachine.Anim.Play("Cat.Idle");
    }

    IEnumerator ChaseTarget(){
        while (true){      
            transform.position = Vector3.MoveTowards(transform.position, StateMachine.AttackTarget.position, StateMachine.ChaseSpeed * Time.deltaTime);
            Vector2 direction = (StateMachine.AttackTarget.position - transform.position).normalized;
            if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
                // Movimiento m�s hacia los lados
                if(direction.x > 0){
                    // Movimiento hacia la derecha
                    StateMachine.Anim.SetInteger("MoveDirection", 4);
                }else{
                    // Movimiento hacia la izquierda
                    StateMachine.Anim.SetInteger("MoveDirection", 3);
                }
            }else{
                // Movimiento m�s hacia arriba o hacia abajo
                if(direction.y > 0){
                    // Movimiento hacia arriba
                    StateMachine.Anim.SetInteger("MoveDirection", 1);
                }else{
                    // Movimiento hacia abajo
                    StateMachine.Anim.SetInteger("MoveDirection", 2);
                }
            }
            yield return null;
        }
    }
}