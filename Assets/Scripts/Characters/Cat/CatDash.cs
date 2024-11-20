using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDash : CatState{
    [SerializeField] private Vector3 lastTargetPos;
    [SerializeField] private float timeSearching;

    void OnEnable(){
        timeSearching = 3f;
        StartCoroutine(DashAttack());
        Cat.PlayMusic("CatDash", true);
    }

    void OnDisable(){
        StopAllCoroutines();
        Cat.PlayAnim("Cat.Idle");
    }

    IEnumerator DashAttack(){
        while(true){
            // Bucle que se ejecutar� mientras el tiempo restante sea mayor que 0
            while(timeSearching > 0){
                timeSearching -= Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            lastTargetPos = Cat.AttackTarget.position;
            Vector2 direction = (Cat.AttackTarget.position - transform.position).normalized;
            if (direction.x >= 0){
                // Movimiento hacia la derecha
                Cat.PlayAnim("Cat.JumpRight");
            }else{
                // Movimiento hacia la izquierda
                Cat.PlayAnim("Cat.JumpLeft");
            }
            Cat.AttackHitbox.Activate(-1);
            Cat.PlaySound("Attack2", false);
            while(transform.position != lastTargetPos){
                transform.position = Vector3.MoveTowards(transform.position, lastTargetPos, Cat.Data.DashSpeed * Time.deltaTime);
                yield return null;
            }
            timeSearching = 3f;
            Cat.AttackHitbox.Deactivate();
            Cat.PlayAnim("Cat.Idle");
        }
    }
}