using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatChase : CatState{
    void OnEnable(){
        StartCoroutine(ChaseTarget());
        Cat.AttackHitbox.Activate(-1);
    }

    void OnDisable(){
        StopAllCoroutines();
        Cat.AttackHitbox.Deactivate();
        Cat.PlayAnim("Cat.Idle");
    }

    IEnumerator ChaseTarget(){
        while (true){      
            transform.position = Vector3.MoveTowards(transform.position, Cat.AttackTarget.position, Cat.Data.ChaseSpeed * Time.deltaTime);
            Vector2 direction = (Cat.AttackTarget.position - transform.position).normalized;
            if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
                // Movimiento m�s hacia los lados
                if(direction.x < 0){
                    // Movimiento hacia la izquierda
                    Cat.PlayAnim("Cat.MoveLeft");
                }else{
                    // Movimiento hacia la derecha
                    Cat.PlayAnim("Cat.MoveRight");
                }
            }else{
                // Movimiento m�s hacia arriba o hacia abajo
                if(direction.y > 0){
                    // Movimiento hacia arriba
                    Cat.PlayAnim("Cat.MoveUp");
                }else{
                    // Movimiento hacia abajo
                    Cat.PlayAnim("Cat.MoveDown");
                }
            }
            yield return null;
        }
    }
}