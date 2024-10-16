using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatStateMachine : StateMachine{
    [SerializeField] private int lives;
    [SerializeField] private bool isOnHitCooldown;

    void Awake(){
        StateList.Add("IDLE", GetComponent<RatIdle>());
        StateList.Add("WALK", GetComponent<RatWalk>());
        StateList.Add("DEATH", GetComponent<RatDeath>());
        ChangeState("IDLE");
    }

    void Start(){
        lives = 3;
        isOnHitCooldown = false;
    }

    public void CheckHealth(){
        if(lives <= 0){
            ChangeState("DEATH");
        }
    }

    public void LoseLife(){
        if(!isOnHitCooldown){
            isOnHitCooldown = true;
            lives -= 1;
            CheckHealth();
            StartCoroutine(HitCooldown());
        }
    }

    private IEnumerator HitCooldown(){
        yield return new WaitForSeconds(2f); // Espera un tiempo antes de permitir otra colisi�n//Equipo de balance cambiar esto
        isOnHitCooldown = false; // Habilita nuevamente la colisi�n
    }
}