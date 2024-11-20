using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : Character{
    public static Action livesChanged, ratDied;
    [SerializeField] private RatData data; public RatData Data{get => data;}
    [SerializeField] private int lives; public int Lives{get => lives;}
    [SerializeField] private float carriedWeight; public float CarriedWeight{get => carriedWeight; set => carriedWeight = value;}
    [SerializeField] private bool isOnHitCooldown;

    void Awake(){
        Initialize(Data);
        lives = Data.MaxLives;
        carriedWeight = 0f;
        isOnHitCooldown = false;
    }

    public void CheckHealth(){
        if(lives <= 0){
            StateMachine.ChangeState("DEATH");
        }
    }

    public void LoseLife(int value){
        if(!isOnHitCooldown){
            isOnHitCooldown = true;
            lives += value;
            livesChanged?.Invoke();
            CheckHealth();
            StartCoroutine(HitCooldown());
            PlaySound("Hit", false);
        }
    }

    public IEnumerator HitCooldown(){
        yield return new WaitForSeconds(2f); // Espera un tiempo antes de permitir otra colisi�n//Equipo de balance cambiar esto
        isOnHitCooldown = false; // Habilita nuevamente la colisi�n
    }
}